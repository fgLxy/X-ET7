using System;

namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class PlayerJoinRoomHandler : AMHandler<G2C_PlayerJoinRoomNotify>
    {
        protected override async ETTask Run(Session session, G2C_PlayerJoinRoomNotify message)
        {
            var task = ETTask.Create(true);
            UnityEngine.Debug.Log($"ÕÊº“º”»Î{message.PlayerId}");
            task.SetResult();
            await task;
        }
    }
}