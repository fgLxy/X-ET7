﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ET
{
	/// <summary>
	/// Config组件会扫描所有的有ConfigAttribute标签的配置,加载进来
	/// </summary>
	public class ConfigComponent : Singleton<ConfigComponent>
	{
		public struct GetAllConfigBytes : IInvoke
		{
			public Type Type => GetType();
		}

		public struct GetOneConfigBytes : IInvoke
		{
			public Type Type => GetType();
			public string ConfigName;
		}

		private readonly Dictionary<Type, ISingleton> allConfig = new Dictionary<Type, ISingleton>();

		public override void Dispose()
		{
			foreach (var kv in this.allConfig)
			{
				kv.Value.Destroy();
			}
		}

		public object LoadOneConfig(Type configType)
		{
			this.allConfig.TryGetValue(configType, out ISingleton oneConfig);
			if (oneConfig != null)
			{
				oneConfig.Destroy();
			}

			byte[] oneConfigBytes = EventSystem.Instance.Invoke<GetOneConfigBytes, byte[]>(new GetOneConfigBytes() { ConfigName = configType.FullName });

			object category = ProtobufHelper.FromBytes(configType, oneConfigBytes, 0, oneConfigBytes.Length);
			ISingleton singleton = category as ISingleton;
			singleton.Register();

			this.allConfig[configType] = singleton;
			return category;
		}

		public void Load()
		{
			this.allConfig.Clear();
			HashSet<Type> types = EventSystem.Instance.GetTypes(typeof(ConfigAttribute));

			Dictionary<string, byte[]> configBytes =
			EventSystem.Instance.Invoke<GetAllConfigBytes, Dictionary<string, byte[]>>(
				new GetAllConfigBytes());

			foreach (Type type in types)
			{
				this.LoadOneInThread(type, configBytes);
			}
		}

		public async ETTask LoadAsync()
		{
			this.allConfig.Clear();
			HashSet<Type> types = EventSystem.Instance.GetTypes(typeof(ConfigAttribute));
			Dictionary<string, byte[]> configBytes =
					EventSystem.Instance.Invoke<GetAllConfigBytes, Dictionary<string, byte[]>>(
						new GetAllConfigBytes());
			using ListComponent<Task> listTasks = ListComponent<Task>.Create();

			foreach (Type type in types)
			{
				Task task = Task.Run(() => LoadOneInThread(type, configBytes));
				listTasks.Add(task);
			}
			await Task.WhenAll(listTasks.ToArray());
			foreach (ISingleton category in this.allConfig.Values)
			{
				category.Register();
			}
		}

		private void LoadOneInThread(Type configType, Dictionary<string, byte[]> configBytes)
		{
			byte[] oneConfigBytes = configBytes[configType.Name];
			object category = null;
			try
            {
				category = ProtobufHelper.FromBytes(configType, oneConfigBytes, 0, oneConfigBytes.Length);
            }
			catch(Exception e)
            {
				Logger.Instance.Error($"{configType.ToString()}序列化异常;{e}");

			}

			lock (this)
			{
				this.allConfig[configType] = category as ISingleton;
			}
		}
	}
}