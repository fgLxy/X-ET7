using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ET.Client
{
    [Invoke]
    public class GetAllConfigBytes : AInvokeHandler<ConfigComponent.GetAllConfigBytes, Dictionary<string, byte[]>>
    {
        public override Dictionary<string, byte[]> Handle(ConfigComponent.GetAllConfigBytes args)
        {
            Dictionary<string, byte[]> output = new Dictionary<string, byte[]>();
            HashSet<Type> configTypes = EventSystem.Instance.GetTypes(typeof(ConfigAttribute));

            if (Define.IsEditor)
            {
                string ct = "cs";
                CodeMode codeMode = Init.Instance.GlobalConfig.CodeMode;
                switch (codeMode)
                {
                    case CodeMode.Client:
                        ct = "c";
                        break;
                    case CodeMode.Server:
                        ct = "s";
                        break;
                    case CodeMode.ClientServer:
                        ct = "cs";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                List<string> startConfigs = new List<string>()
                {
                    "StartMachineConfigCategory",
                    "StartProcessConfigCategory",
                    "StartSceneConfigCategory",
                    "StartZoneConfigCategory",
                };
                foreach (Type configType in configTypes)
                {
                    string configFilePath;
                    if (startConfigs.Contains(configType.Name))
                    {
                        configFilePath = $"../Config/Excel/{ct}/{Options.Instance.StartConfig}/{configType.Name}.bytes";
                    }
                    else
                    {
                        configFilePath = $"../Config/Excel/{ct}/{configType.Name}.bytes";
                    }
                    output[configType.Name] = File.ReadAllBytes(configFilePath);
                }
            }
            else
            {
                foreach (Type configType in configTypes)
                {
                    TextAsset v = ResComponent.Instance.LoadAsset<TextAsset>(configType.Name);
                    if (v == null)
                    {
                        Log.Error($"{configType.Name} cant load asset.");
                        continue;
                    }
                    output[configType.Name] = v.bytes;
                }
            }

            return output;
        }
    }

    [Invoke]
    public class GetOneConfigBytes : AInvokeHandler<ConfigComponent.GetOneConfigBytes, byte[]>
    {
        public override byte[] Handle(ConfigComponent.GetOneConfigBytes args)
        {
            //TextAsset v = ResourcesComponent.Instance.GetAsset("config.unity3d", configName) as TextAsset;
            //return v.bytes;
            throw new NotImplementedException("client cant use LoadOneConfig");
        }
    }
}