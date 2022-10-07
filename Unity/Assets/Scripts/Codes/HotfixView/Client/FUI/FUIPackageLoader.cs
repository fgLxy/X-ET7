/** This is an automatically generated class by FairyGUI. Please do not modify it. **/


namespace ET.Client
{
    public static class FUIPackageLoader
    {
        public static async ETTask LoadPackagesAsync(FUIComponent fuiComponent)
        {
            using (ListComponent<ETTask> tasks = ListComponent<ETTask>.Create())
            {
                tasks.Add(fuiComponent.AddPackageAsync("CardCommon"));
                tasks.Add(fuiComponent.AddPackageAsync("Common"));
                tasks.Add(fuiComponent.AddPackageAsync("GamePlay"));
                tasks.Add(fuiComponent.AddPackageAsync("Lobby"));
                tasks.Add(fuiComponent.AddPackageAsync("Login"));

                await ETTaskHelper.WaitAll(tasks);
            }
            ET.CardCommon.CardCommonBinder.BindAll();
            ET.Common.CommonBinder.BindAll();
            ET.GamePlay.GamePlayBinder.BindAll();
            ET.Lobby.LobbyBinder.BindAll();
            ET.Login.LoginBinder.BindAll();
        }
    }
}