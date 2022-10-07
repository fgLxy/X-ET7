using HybridCLR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace ET
{
	public class CodeLoader: Singleton<CodeLoader>
	{
		public static string[] AOTS = new string[]
		{
			"mscorlib.dll",
			"System.dll",
			"System.Core.dll", // 如果使用了Linq，需要这个
            "Unity.Core.dll",
			"Unity.Mono.dll",
			"Unity.ThirdParty.dll",
			"MongoDB.Bson.dll",
			"CommandLine.dll",
			"NLog.dll",
		};

		private Assembly assembly;

		public async void Start()
		{
			
			if (Define.EnableCodes)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				Dictionary<string, Type> types = AssemblyHelper.GetAssemblyTypes(assemblies);
				EventSystem.Instance.Add(types);
				foreach (Assembly ass in assemblies)
				{
					string name = ass.GetName().Name;
					if (name == "Unity.Model.Codes")
					{
						this.assembly = ass;
					}
				}
				
				IStaticMethod start = new StaticMethod(assembly, "ET.Entry", "Start");
				UnityEngine.Debug.Log("Try Run Start");
				start.Run();
			}
			else
			{
				byte[] assBytes;
				byte[] pdbBytes;
				if (!Define.IsEditor)
				{
					assBytes = await ResComponent.Instance.LoadRawFileDataAsync("Model.dll").GetAwaiter();
					pdbBytes = await ResComponent.Instance.LoadRawFileDataAsync("Model.pdb").GetAwaiter();
				}
				else
				{
					assBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, "Model.dll"));
					pdbBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, "Model.pdb"));
				}
				LoadAOTDLL();

				assembly = Assembly.Load(assBytes, pdbBytes);
				var hotfixASM = await LoadHotfix();

				RegistEvents(hotfixASM);

				IStaticMethod start = new StaticMethod(assembly, "ET.Entry", "Start");
				start.Run();
			}
		}

        private void RegistEvents(Assembly hotfixAsm)
        {
			var types = AssemblyHelper.GetAssemblyTypes(typeof(Game).Assembly, this.assembly, hotfixAsm);
			EventSystem.Instance.Add(types);
		}

        private async void LoadAOTDLL()
        {
			if (Define.EnableCodes || Define.IsEditor)
            {
				return;
            }
			static unsafe void LoadMetadataForAOTAssembly(byte[] dllBytes)
			{
				fixed (byte* ptr = dllBytes)
				{
                // 加载assembly对应的dll，会自动为它hook。一旦aot泛型函数的native函数不存在，用解释器版本代码
					var err = RuntimeApi.LoadMetadataForAOTAssembly((IntPtr)ptr, dllBytes.Length);
					Debug.Log("LoadMetadataForAOTAssembly. ret:" + err);
				}
			}

			foreach (var key in AOTS)
            {
				var dll = await ResComponent.Instance.LoadRawFileDataAsync(key).GetAwaiter();
				LoadMetadataForAOTAssembly(dll);
			}
		}

        // 热重载调用该方法
        public async ETTask<Assembly> LoadHotfix()
		{
			byte[] assBytes = null;
			byte[] pdbBytes = null;
			if (!Define.IsEditor)
            {
				assBytes = await ResComponent.Instance.LoadRawFileDataAsync("Hotfix.dll").GetAwaiter();
				pdbBytes = await ResComponent.Instance.LoadRawFileDataAsync("Hotfix.pdb").GetAwaiter();
			}
			else
			{
				// 傻屌Unity在这里搞了个傻逼优化，认为同一个路径的dll，返回的程序集就一样。所以这里每次编译都要随机名字
				string[] logicFiles = Directory.GetFiles(Define.BuildOutputDir, "Hotfix_*.dll");
				if (logicFiles.Length != 1)
				{
					throw new Exception("Logic dll count != 1");
				}
				string logicName = Path.GetFileNameWithoutExtension(logicFiles[0]);
				assBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.dll"));
				pdbBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.pdb"));
			}
			return Assembly.Load(assBytes, pdbBytes);
		}
	}
}