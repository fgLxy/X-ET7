public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ constraint implement type
	// }} 

	// {{ AOT generic type
	//ET.AEvent`1<ET.EventType.InitShareEvent>
	//ET.AEvent`1<ET.EventType.InitClientEvent>
	//ET.AEvent`1<ET.EventType.LoginFinish>
	//ET.AEvent`1<ET.EventType.EnterGamePlayFinish>
	//ET.AEvent`1<ET.EventType.ChangeRotation>
	//ET.AEvent`1<ET.EventType.ChangePosition>
	//ET.AEvent`1<ET.EventType.AfterUnitCreate>
	//ET.AEvent`1<ET.EventType.NumbericChange>
	//ET.AEvent`1<ET.EventType.SceneChangeStart>
	//ET.AEvent`1<ET.EventType.AfterCreateCurrentScene>
	//ET.AEvent`1<ET.EventType.AfterCreateClientScene>
	//ET.AEvent`1<ET.Client.NetClientComponentOnRead>
	//ET.AInvokeHandler`2<ET.ConfigComponent/GetOneConfigBytes,System.Object>
	//ET.AInvokeHandler`2<ET.ConfigComponent/GetAllConfigBytes,System.Object>
	//ET.ATimer`1<System.Object>
	//ET.AwakeSystem`1<System.Object>
	//ET.AwakeSystem`2<System.Object,System.Net.Sockets.AddressFamily>
	//ET.AwakeSystem`2<System.Object,System.Object>
	//ET.AwakeSystem`2<System.Object,System.Int32>
	//ET.AwakeSystem`3<System.Object,System.Object,System.Int32>
	//ET.ConfigSingleton`1<System.Object>
	//ET.DestroySystem`1<System.Object>
	//ET.ETAsyncTaskMethodBuilder`1<ET.Client.Wait_UnitStop>
	//ET.ETAsyncTaskMethodBuilder`1<System.UInt32>
	//ET.ETAsyncTaskMethodBuilder`1<ET.Client.Wait_SceneChangeFinish>
	//ET.ETAsyncTaskMethodBuilder`1<System.Object>
	//ET.ETAsyncTaskMethodBuilder`1<System.Int32>
	//ET.ETAsyncTaskMethodBuilder`1<System.Byte>
	//ET.ETAsyncTaskMethodBuilder`1<System.ValueTuple`2<System.UInt32,System.Object>>
	//ET.ETAsyncTaskMethodBuilder`1<ET.Client.Wait_CreateMyUnit>
	//ET.ETTask`1<UnityEngine.SceneManagement.Scene>
	//ET.ETTask`1<System.UInt32>
	//ET.ETTask`1<System.ValueTuple`2<System.UInt32,System.Object>>
	//ET.ETTask`1<System.Object>
	//ET.ETTask`1<ET.Client.Wait_CreateMyUnit>
	//ET.ETTask`1<ET.Client.Wait_UnitStop>
	//ET.ETTask`1<System.Int32>
	//ET.ETTask`1<System.Byte>
	//ET.ETTask`1<ET.Client.Wait_SceneChangeFinish>
	//ET.IAwake`1<System.Int32>
	//ET.IAwake`1<System.Object>
	//ET.IAwake`1<System.Net.Sockets.AddressFamily>
	//ET.IAwake`2<System.Object,System.Int32>
	//ET.LateUpdateSystem`1<System.Object>
	//ET.ListComponent`1<System.Object>
	//ET.ListComponent`1<Unity.Mathematics.float3>
	//ET.LoadSystem`1<System.Object>
	//ET.MultiMap`2<System.Object,System.Object>
	//ET.Singleton`1<System.Object>
	//ET.UpdateSystem`1<System.Object>
	//System.Action`1<System.Object>
	//System.Action`2<System.Int64,System.Int32>
	//System.Action`3<System.Int64,System.Int64,System.Object>
	//System.Collections.Generic.Dictionary`2<ET.Client.PanelId,ET.Client.PanelInfo>
	//System.Collections.Generic.Dictionary`2<ET.Client.PanelId,System.Object>
	//System.Collections.Generic.Dictionary`2<System.Object,ET.Client.PanelInfo>
	//System.Collections.Generic.Dictionary`2<System.Object,System.Int64>
	//System.Collections.Generic.Dictionary`2<System.Int32,ET.RpcInfo>
	//System.Collections.Generic.Dictionary`2<System.Object,System.Object>
	//System.Collections.Generic.Dictionary`2<System.Int32,System.Object>
	//System.Collections.Generic.Dictionary`2<System.UInt16,System.Object>
	//System.Collections.Generic.Dictionary`2<System.Int32,System.Int64>
	//System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Object>
	//System.Collections.Generic.Dictionary`2/ValueCollection<System.Int32,System.Object>
	//System.Collections.Generic.Dictionary`2/ValueCollection/Enumerator<System.Int32,System.Object>
	//System.Collections.Generic.HashSet`1<System.Object>
	//System.Collections.Generic.HashSet`1<System.UInt16>
	//System.Collections.Generic.HashSet`1/Enumerator<System.Object>
	//System.Collections.Generic.IDictionary`2<System.Object,System.Object>
	//System.Collections.Generic.KeyValuePair`2<System.Int32,System.Object>
	//System.Collections.Generic.List`1<ET.Client.PanelId>
	//System.Collections.Generic.List`1<System.Int64>
	//System.Collections.Generic.List`1<System.Object>
	//System.Collections.Generic.List`1<System.Int32>
	//System.Collections.Generic.List`1<Unity.Mathematics.float3>
	//System.Collections.Generic.List`1/Enumerator<System.Int64>
	//System.Collections.Generic.List`1/Enumerator<System.Object>
	//System.Collections.Generic.List`1/Enumerator<Unity.Mathematics.float3>
	//System.Collections.Generic.SortedDictionary`2<System.Int32,System.Object>
	//System.Collections.Generic.SortedDictionary`2<System.Object,System.Object>
	//System.Collections.Generic.SortedDictionary`2/ValueCollection<System.Int32,System.Object>
	//System.Collections.Generic.SortedDictionary`2/ValueCollection/Enumerator<System.Int32,System.Object>
	//System.Collections.Generic.Stack`1<ET.Client.PanelId>
	//System.Func`1<System.Object>
	//System.Func`2<System.Object,System.Object>
	//System.Runtime.CompilerServices.TaskAwaiter`1<System.ValueTuple`2<System.UInt32,System.UInt32>>
	//System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>
	//System.Threading.Tasks.Task`1<System.ValueTuple`2<System.UInt32,System.UInt32>>
	//System.Threading.Tasks.Task`1<System.Object>
	//System.ValueTuple`2<System.UInt32,System.Object>
	//System.ValueTuple`2<System.UInt32,System.UInt32>
	// }}

	public void RefMethods()
	{
		// System.Object ET.Entity::AddChild<System.Object>(System.Boolean)
		// System.Object ET.Entity::AddChildWithId<System.Object,System.Int32>(System.Int64,System.Int32,System.Boolean)
		// System.Object ET.Entity::AddComponent<System.Object,System.Net.Sockets.AddressFamily>(System.Net.Sockets.AddressFamily,System.Boolean)
		// System.Object ET.Entity::AddComponent<System.Object,System.Object,System.Int32>(System.Object,System.Int32,System.Boolean)
		// System.Object ET.Entity::AddComponent<System.Object>(System.Boolean)
		// System.Object ET.Entity::GetChild<System.Object>(System.Int64)
		// System.Object ET.Entity::GetComponent<System.Object>()
		// System.Object ET.Entity::GetParent<System.Object>()
		// System.Void ET.Entity::RemoveComponent<System.Object>()
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.PlayerJoinRoomHandler/<Run>d__0>(System.Object&,ET.Client.PlayerJoinRoomHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.LoginComponentSystem/<Login>d__1>(System.Object&,ET.Client.LoginComponentSystem/<Login>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Entry/<StartAsync>d__1>(System.Object&,ET.Entry/<StartAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.PingComponentAwakeSystem/<PingAsync>d__1>(System.Object&,ET.Client.PingComponentAwakeSystem/<PingAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.RouterAddressComponentSystem/<Init>d__1>(System.Object&,ET.Client.RouterAddressComponentSystem/<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.RouterAddressComponentSystem/<GetAllRouter>d__2>(System.Object&,ET.Client.RouterAddressComponentSystem/<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.GameStartHandler/<Run>d__0>(System.Object&,ET.Client.GameStartHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_RemoveUnitsHandler/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_RemoveUnitsHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.SceneChangeHelper/<SceneChangeTo>d__0>(System.Object&,ET.Client.SceneChangeHelper/<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CreateMyUnitHandler/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CreateMyUnitHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.FUIHelper/<>c__DisplayClass2_0/<<AddListnerAsync>g__ClickActionAsync|0>d>(System.Object&,ET.Client.FUIHelper/<>c__DisplayClass2_0/<<AddListnerAsync>g__ClickActionAsync|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.M2C_StartSceneChangeHandler/<Run>d__0>(System.Object&,ET.Client.M2C_StartSceneChangeHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_StopHandler/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_StopHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.M2C_PathfindingResultHandler/<Run>d__0>(System.Object&,ET.Client.M2C_PathfindingResultHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.EnterMapHelper/<EnterMapAsync>d__0>(System.Object&,ET.Client.EnterMapHelper/<EnterMapAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.AI_XunLuo/<Execute>d__1>(System.Object&,ET.Client.AI_XunLuo/<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.AI_Attack/<Execute>d__1>(System.Object&,ET.Client.AI_Attack/<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.NumericChangeEvent_NotifyWatcher/<Run>d__0>(ET.ETTaskCompleted&,ET.NumericChangeEvent_NotifyWatcher/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.InitShareEventHandler/<Run>d__0>(ET.ETTaskCompleted&,ET.InitShareEventHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CreateUnitsHandler/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CreateUnitsHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.RouterAddressComponentSystem/<WaitTenMinGetAllRouter>d__3>(System.Object&,ET.Client.RouterAddressComponentSystem/<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.RouterCheckComponentAwakeSystem/<CheckAsync>d__1>(System.Object&,ET.Client.RouterCheckComponentAwakeSystem/<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.AFsmNodeHandler/<OnEnter>d__4>(ET.ETTaskCompleted&,ET.AFsmNodeHandler/<OnEnter>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.FUIComponentSystem/<LoadFUIEntitysAsync>d__29>(System.Object&,ET.Client.FUIComponentSystem/<LoadFUIEntitysAsync>d__29&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.FUIComponentSystem/<HideAndShowPanelStackAsync>d__11>(System.Object&,ET.Client.FUIComponentSystem/<HideAndShowPanelStackAsync>d__11&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.FUIComponentSystem/<ShowPanelAsync>d__7>(System.Object&,ET.Client.FUIComponentSystem/<ShowPanelAsync>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.UIPackageHelper/<AddPackageAsync>d__1>(System.Object&,ET.Client.UIPackageHelper/<AddPackageAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.InitClientEventHandler/<Run>d__0>(System.Object&,ET.Client.InitClientEventHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.LoginPanelSystem/<Login>d__1>(System.Object&,ET.Client.LoginPanelSystem/<Login>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.LoginFinish_CreateLobbyUI/<Run>d__0>(System.Object&,ET.Client.LoginFinish_CreateLobbyUI/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.LobbyPanelSystem/<Enter1V1>d__1>(System.Object&,ET.Client.LobbyPanelSystem/<Enter1V1>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.EnterGamePlayHandler/<Run>d__0>(System.Object&,ET.Client.EnterGamePlayHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangeRotation_SyncGameObjectRotation/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangeRotation_SyncGameObjectRotation/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.FUIPackageLoader/<LoadPackagesAsync>d__0>(System.Object&,ET.Client.FUIPackageLoader/<LoadPackagesAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterUnitCreate_CreateUnitView/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterUnitCreate_CreateUnitView/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.UIPackageHelper/<InnerLoader>d__2>(System.Object&,ET.Client.UIPackageHelper/<InnerLoader>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.AfterUnitCreate_CreateUnitView/<Run>d__0>(System.Object&,ET.Client.AfterUnitCreate_CreateUnitView/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.FUIHelper/<>c__DisplayClass0_0/<<AddListnerAsync>g__ClickActionAsync|0>d>(System.Object&,ET.Client.FUIHelper/<>c__DisplayClass0_0/<<AddListnerAsync>g__ClickActionAsync|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Object,ET.Client.SceneChangeStart_AddComponent/<Run>d__0>(System.Object&,ET.Client.SceneChangeStart_AddComponent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterCreateCurrentScene_AddComponent/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterCreateCurrentScene_AddComponent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterCreateClientScene_AddComponent/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterCreateClientScene_AddComponent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.NetClientComponentOnReadEvent/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.NetClientComponentOnReadEvent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter`1<System.ValueTuple`2<System.UInt32,System.UInt32>>,ET.Client.RouterCheckComponentAwakeSystem/<CheckAsync>d__1>(System.Runtime.CompilerServices.TaskAwaiter`1<System.ValueTuple`2<System.UInt32,System.UInt32>>&,ET.Client.RouterCheckComponentAwakeSystem/<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangePosition_SyncGameObjectPos/<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangePosition_SyncGameObjectPos/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.UIPackageHelper/<InnerLoader>d__2>(ET.Client.UIPackageHelper/<InnerLoader>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.AFsmNodeHandler/<OnEnter>d__4>(ET.AFsmNodeHandler/<OnEnter>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.FUIHelper/<>c__DisplayClass2_0/<<AddListnerAsync>g__ClickActionAsync|0>d>(ET.Client.FUIHelper/<>c__DisplayClass2_0/<<AddListnerAsync>g__ClickActionAsync|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Entry/<StartAsync>d__1>(ET.Entry/<StartAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.FUIHelper/<>c__DisplayClass0_0/<<AddListnerAsync>g__ClickActionAsync|0>d>(ET.Client.FUIHelper/<>c__DisplayClass0_0/<<AddListnerAsync>g__ClickActionAsync|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.UIPackageHelper/<AddPackageAsync>d__1>(ET.Client.UIPackageHelper/<AddPackageAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.InitShareEventHandler/<Run>d__0>(ET.InitShareEventHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.FUIComponentSystem/<LoadFUIEntitysAsync>d__29>(ET.Client.FUIComponentSystem/<LoadFUIEntitysAsync>d__29&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.NetClientComponentOnReadEvent/<Run>d__0>(ET.Client.NetClientComponentOnReadEvent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.RouterAddressComponentSystem/<WaitTenMinGetAllRouter>d__3>(ET.Client.RouterAddressComponentSystem/<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.RouterAddressComponentSystem/<GetAllRouter>d__2>(ET.Client.RouterAddressComponentSystem/<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.RouterAddressComponentSystem/<Init>d__1>(ET.Client.RouterAddressComponentSystem/<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.PingComponentAwakeSystem/<PingAsync>d__1>(ET.Client.PingComponentAwakeSystem/<PingAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.LoginComponentSystem/<Login>d__1>(ET.Client.LoginComponentSystem/<Login>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.PlayerJoinRoomHandler/<Run>d__0>(ET.Client.PlayerJoinRoomHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.GameStartHandler/<Run>d__0>(ET.Client.GameStartHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.M2C_RemoveUnitsHandler/<Run>d__0>(ET.Client.M2C_RemoveUnitsHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.M2C_CreateUnitsHandler/<Run>d__0>(ET.Client.M2C_CreateUnitsHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.M2C_CreateMyUnitHandler/<Run>d__0>(ET.Client.M2C_CreateMyUnitHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.SceneChangeHelper/<SceneChangeTo>d__0>(ET.Client.SceneChangeHelper/<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.M2C_StartSceneChangeHandler/<Run>d__0>(ET.Client.M2C_StartSceneChangeHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.M2C_StopHandler/<Run>d__0>(ET.Client.M2C_StopHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.M2C_PathfindingResultHandler/<Run>d__0>(ET.Client.M2C_PathfindingResultHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.EnterMapHelper/<EnterMapAsync>d__0>(ET.Client.EnterMapHelper/<EnterMapAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.AI_XunLuo/<Execute>d__1>(ET.Client.AI_XunLuo/<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.AI_Attack/<Execute>d__1>(ET.Client.AI_Attack/<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.NumericChangeEvent_NotifyWatcher/<Run>d__0>(ET.NumericChangeEvent_NotifyWatcher/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.AfterCreateClientScene_AddComponent/<Run>d__0>(ET.Client.AfterCreateClientScene_AddComponent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.AfterCreateCurrentScene_AddComponent/<Run>d__0>(ET.Client.AfterCreateCurrentScene_AddComponent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.RouterCheckComponentAwakeSystem/<CheckAsync>d__1>(ET.Client.RouterCheckComponentAwakeSystem/<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.AfterUnitCreate_CreateUnitView/<Run>d__0>(ET.Client.AfterUnitCreate_CreateUnitView/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.ChangePosition_SyncGameObjectPos/<Run>d__0>(ET.Client.ChangePosition_SyncGameObjectPos/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.SceneChangeStart_AddComponent/<Run>d__0>(ET.Client.SceneChangeStart_AddComponent/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.FUIPackageLoader/<LoadPackagesAsync>d__0>(ET.Client.FUIPackageLoader/<LoadPackagesAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.EnterGamePlayHandler/<Run>d__0>(ET.Client.EnterGamePlayHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.ChangeRotation_SyncGameObjectRotation/<Run>d__0>(ET.Client.ChangeRotation_SyncGameObjectRotation/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.LoginFinish_CreateLobbyUI/<Run>d__0>(ET.Client.LoginFinish_CreateLobbyUI/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.LobbyPanelSystem/<Enter1V1>d__1>(ET.Client.LobbyPanelSystem/<Enter1V1>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.InitClientEventHandler/<Run>d__0>(ET.Client.InitClientEventHandler/<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.FUIComponentSystem/<ShowPanelAsync>d__7>(ET.Client.FUIComponentSystem/<ShowPanelAsync>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.FUIComponentSystem/<HideAndShowPanelStackAsync>d__11>(ET.Client.FUIComponentSystem/<HideAndShowPanelStackAsync>d__11&)
		// System.Void ET.ETAsyncTaskMethodBuilder::Start<ET.Client.LoginPanelSystem/<Login>d__1>(ET.Client.LoginPanelSystem/<Login>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Byte>::AwaitUnsafeOnCompleted<System.Object,ET.MoveComponentSystem/<MoveToAsync>d__5>(System.Object&,ET.MoveComponentSystem/<MoveToAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Int32>::AwaitUnsafeOnCompleted<System.Object,ET.Client.MoveHelper/<MoveToAsync>d__0>(System.Object&,ET.Client.MoveHelper/<MoveToAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Byte>::AwaitUnsafeOnCompleted<System.Object,ET.Client.MoveHelper/<MoveToAsync>d__1>(System.Object&,ET.Client.MoveHelper/<MoveToAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted<System.Object,ET.Client.FUIComponentSystem/<ShowFUIEntityAsync>d__18>(System.Object&,ET.Client.FUIComponentSystem/<ShowFUIEntityAsync>d__18&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.UInt32>::AwaitUnsafeOnCompleted<System.Object,ET.Client.RouterHelper/<Connect>d__2>(System.Object&,ET.Client.RouterHelper/<Connect>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted<System.Object,ET.Client.UIPackageHelper/<CreateObjectAsync>d__0>(System.Object&,ET.Client.UIPackageHelper/<CreateObjectAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted<System.Object,ET.Client.RouterHelper/<CreateRouterSession>d__0>(System.Object&,ET.Client.RouterHelper/<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted<System.Object,ET.SessionSystem/<Call>d__3>(System.Object&,ET.SessionSystem/<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted<System.Object,ET.SessionSystem/<Call>d__4>(System.Object&,ET.SessionSystem/<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.SceneFactory/<CreateClientScene>d__0>(ET.ETTaskCompleted&,ET.Client.SceneFactory/<CreateClientScene>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>,ET.Client.HttpClientHelper/<Get>d__0>(System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>&,ET.Client.HttpClientHelper/<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.ValueTuple`2<System.UInt32,System.Object>>::AwaitUnsafeOnCompleted<System.Object,ET.Client.RouterHelper/<GetRouterAddress>d__1>(System.Object&,ET.Client.RouterHelper/<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Byte>::Start<ET.MoveComponentSystem/<MoveToAsync>d__5>(ET.MoveComponentSystem/<MoveToAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::Start<ET.Client.FUIComponentSystem/<ShowFUIEntityAsync>d__18>(ET.Client.FUIComponentSystem/<ShowFUIEntityAsync>d__18&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::Start<ET.SessionSystem/<Call>d__4>(ET.SessionSystem/<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<ET.Client.Wait_CreateMyUnit>::Start<ET.ObjectWaitSystem/<Wait>d__4`1<ET.Client.Wait_CreateMyUnit>>(ET.ObjectWaitSystem/<Wait>d__4`1<ET.Client.Wait_CreateMyUnit>&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.UInt32>::Start<ET.Client.RouterHelper/<Connect>d__2>(ET.Client.RouterHelper/<Connect>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.ValueTuple`2<System.UInt32,System.Object>>::Start<ET.Client.RouterHelper/<GetRouterAddress>d__1>(ET.Client.RouterHelper/<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::Start<ET.SessionSystem/<Call>d__3>(ET.SessionSystem/<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Int32>::Start<ET.Client.MoveHelper/<MoveToAsync>d__0>(ET.Client.MoveHelper/<MoveToAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::Start<ET.Client.RouterHelper/<CreateRouterSession>d__0>(ET.Client.RouterHelper/<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::Start<ET.Client.SceneFactory/<CreateClientScene>d__0>(ET.Client.SceneFactory/<CreateClientScene>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<ET.Client.Wait_UnitStop>::Start<ET.ObjectWaitSystem/<Wait>d__4`1<ET.Client.Wait_UnitStop>>(ET.ObjectWaitSystem/<Wait>d__4`1<ET.Client.Wait_UnitStop>&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::Start<ET.Client.UIPackageHelper/<CreateObjectAsync>d__0>(ET.Client.UIPackageHelper/<CreateObjectAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Object>::Start<ET.Client.HttpClientHelper/<Get>d__0>(ET.Client.HttpClientHelper/<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<System.Byte>::Start<ET.Client.MoveHelper/<MoveToAsync>d__1>(ET.Client.MoveHelper/<MoveToAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder`1<ET.Client.Wait_SceneChangeFinish>::Start<ET.ObjectWaitSystem/<Wait>d__4`1<ET.Client.Wait_SceneChangeFinish>>(ET.ObjectWaitSystem/<Wait>d__4`1<ET.Client.Wait_SceneChangeFinish>&)
		// System.Object ET.EventSystem::Invoke<ET.NavmeshComponent/RecastFileLoader,System.Object>(System.Int32,ET.NavmeshComponent/RecastFileLoader)
		// System.Void ET.EventSystem::Publish<ET.EventType.ChangeRotation>(ET.Scene,ET.EventType.ChangeRotation)
		// System.Void ET.EventSystem::Publish<ET.EventType.NumbericChange>(ET.Scene,ET.EventType.NumbericChange)
		// System.Void ET.EventSystem::Publish<ET.EventType.ChangePosition>(ET.Scene,ET.EventType.ChangePosition)
		// System.Void ET.EventSystem::Publish<ET.EventType.SceneChangeStart>(ET.Scene,ET.EventType.SceneChangeStart)
		// System.Void ET.EventSystem::Publish<ET.EventType.MoveStop>(ET.Scene,ET.EventType.MoveStop)
		// System.Void ET.EventSystem::Publish<ET.EventType.AfterCreateCurrentScene>(ET.Scene,ET.EventType.AfterCreateCurrentScene)
		// System.Void ET.EventSystem::Publish<ET.EventType.MoveStart>(ET.Scene,ET.EventType.MoveStart)
		// System.Void ET.EventSystem::Publish<ET.EventType.AfterUnitCreate>(ET.Scene,ET.EventType.AfterUnitCreate)
		// System.Void ET.EventSystem::Publish<ET.EventType.EnterGamePlayFinish>(ET.Scene,ET.EventType.EnterGamePlayFinish)
		// System.Void ET.EventSystem::Publish<ET.EventType.SceneChangeFinish>(ET.Scene,ET.EventType.SceneChangeFinish)
		// System.Void ET.EventSystem::Publish<ET.Client.NetClientComponentOnRead>(ET.Scene,ET.Client.NetClientComponentOnRead)
		// System.Void ET.EventSystem::Publish<ET.EventType.AfterCreateClientScene>(ET.Scene,ET.EventType.AfterCreateClientScene)
		// ET.ETTask ET.EventSystem::PublishAsync<ET.EventType.LoginFinish>(ET.Scene,ET.EventType.LoginFinish)
		// ET.ETTask ET.EventSystem::PublishAsync<ET.EventType.AppStartInitFinish>(ET.Scene,ET.EventType.AppStartInitFinish)
		// ET.ETTask ET.EventSystem::PublishAsync<ET.EventType.InitServerEvent>(ET.Scene,ET.EventType.InitServerEvent)
		// ET.ETTask ET.EventSystem::PublishAsync<ET.EventType.InitClientEvent>(ET.Scene,ET.EventType.InitClientEvent)
		// ET.ETTask ET.EventSystem::PublishAsync<ET.EventType.InitShareEvent>(ET.Scene,ET.EventType.InitShareEvent)
		// System.Object ET.Game::AddSingleton<System.Object>()
		// System.Object ET.JsonHelper::FromJson<System.Object>(System.String)
		// System.Void ET.RandomGenerator::BreakRank<System.Object>(System.Collections.Generic.List`1<System.Object>)
		// System.Object ET.ResComponent::LoadAsset<System.Object>(System.String)
		// ET.ETTask`1<System.Object> ET.ResComponent::LoadAssetAsync<System.Object>(System.String)
		// System.String ET.StringHelper::ArrayToString<System.Single>(System.Single[])
		// ET.Client.Wait_UnitStop System.Activator::CreateInstance<ET.Client.Wait_UnitStop>()
		// ET.Client.Wait_CreateMyUnit System.Activator::CreateInstance<ET.Client.Wait_CreateMyUnit>()
		// ET.Client.Wait_SceneChangeFinish System.Activator::CreateInstance<ET.Client.Wait_SceneChangeFinish>()
		// ET.RpcInfo[] System.Linq.Enumerable::ToArray<ET.RpcInfo>(System.Collections.Generic.IEnumerable`1<ET.RpcInfo>)
		// System.Object[] System.Linq.Enumerable::ToArray<System.Object>(System.Collections.Generic.IEnumerable`1<System.Object>)
		// System.Object UnityEngine.GameObject::GetComponent<System.Object>()
		// System.Object UnityEngine.Object::Instantiate<System.Object>(System.Object,UnityEngine.Transform,System.Boolean)
	}
}