namespace ET.Client
{
    public class GameStartHandler : AMHandler<G2C_GameStartNotify>
    {
        protected override async ETTask Run(Session session, G2C_GameStartNotify message)
        {
            // 等待场景切换完成
            await session.DomainScene().CurrentScene().GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();
            var scene = session.DomainScene().CurrentScene();
            EventSystem.Instance.Publish(scene, new EventType.EnterGamePlayFinish());
        }
    }
}