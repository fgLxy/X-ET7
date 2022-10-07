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
            WinPeriod.Init();
            MongoRegister.Init();
            ProtobufRegister.Init();
            Game.AddSingleton<NetServices>();
            Game.AddSingleton<Root>();
            await Game.AddSingleton<ConfigComponent>().LoadAsync();
            await EventSystem.Instance.PublishAsync(Root.Instance.Scene, new EventType.InitShareEvent());
            await EventSystem.Instance.PublishAsync(Root.Instance.Scene, new EventType.InitServerEvent());
            await EventSystem.Instance.PublishAsync(Root.Instance.Scene, new EventType.InitClientEvent());
        }
    }
}