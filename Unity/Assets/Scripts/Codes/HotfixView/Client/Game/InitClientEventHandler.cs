using System;
using System.IO;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Process)]
    public class InitClientEventHandler: AEvent<ET.EventType.InitClientEvent>
    {
        protected override async ETTask Run(Scene scene, ET.EventType.InitClientEvent args)
        {
            Logger.Instance.Info("Init Client");
            // 加载配置
            Root.Instance.Scene.AddComponent<GlobalComponent>();
            
            Root.Instance.Scene.AddComponent<FsmDispatcherComponent>();

            Scene clientScene = await SceneFactory.CreateClientScene(1, "Game");

            FUIComponent fuiComponent = clientScene.GetComponent<FUIComponent>();

            // 加载 Packages
            await FUIPackageLoader.LoadPackagesAsync(fuiComponent);
            
            await clientScene.GetComponent<FUIComponent>().ShowPanelAsync(PanelId.LoginPanel);

            await EventSystem.Instance.PublishAsync(clientScene, new EventType.AppStartInitFinish());
        }
    }
}