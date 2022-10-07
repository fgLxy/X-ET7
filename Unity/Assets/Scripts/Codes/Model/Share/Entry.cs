namespace ET
{
    namespace EventType
    {
        public struct InitShareEvent
        {
        }   
        
        public struct InitServerEvent
        {
        } 
        
        public struct InitClientEvent
        {
        } 
    }
    
    public static class Entry
    {
        public static void Start()
        {
            StartAsync().Coroutine();
        }
        
        private static async ETTask StartAsync()
        {
            Logger.Instance.Info("Game Entry");
            WinPeriod.Init();
            Logger.Instance.Info("Game Entry1");
            MongoRegister.Init();
            Logger.Instance.Info("Game Entry2");
            ProtobufRegister.Init();
            Logger.Instance.Info("Game Entry3");
            Game.AddSingleton<NetServices>();
            Logger.Instance.Info("Game Entry4");
            Game.AddSingleton<Root>();
            Logger.Instance.Info("Game Entry5");
            await Game.AddSingleton<ConfigComponent>().LoadAsync();
            Logger.Instance.Info("Game Entry6");
            await EventSystem.Instance.PublishAsync(Root.Instance.Scene, new EventType.InitShareEvent());
            Logger.Instance.Info("Game Entry7");
            await EventSystem.Instance.PublishAsync(Root.Instance.Scene, new EventType.InitServerEvent());
            Logger.Instance.Info("Game Entry8");
            await EventSystem.Instance.PublishAsync(Root.Instance.Scene, new EventType.InitClientEvent());
            Logger.Instance.Info("Game Entry9");
        }
    }
}