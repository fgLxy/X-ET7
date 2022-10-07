function onPublishFinish(handler, path)
	local settings = handler.project:GetSettings("Publish").codeGeneration

	local packagesCSharp  = handler.project.allPackages
	local exportCodePath = path..'/HotfixView/Client/FUI/'
	handler:SetupCodeFolder(exportCodePath, "cs")
	local packages = {}

	local count = packagesCSharp.Count
	for i=0,count - 1 do
		table.insert(packages, packagesCSharp[i].name)
	end

	local writer = CodeWriter.new()

	

	writer:writeln()
	writer:writeln('namespace ET.Client')
	writer:startBlock()

	writer:writeln('public static class FUIPackageLoader')
	writer:startBlock()

	writer:writeln('public static async ETTask LoadPackagesAsync(FUIComponent fuiComponent)')
	writer:startBlock()

	writer:writeln('using (ListComponent<ETTask> tasks = ListComponent<ETTask>.Create())')
	writer:startBlock()

	for _, v in ipairs(packages) do
		writer:writeln('tasks.Add(fuiComponent.AddPackageAsync("%s"));', v)
	end
	writer:writeln()
	writer:writeln('await ETTaskHelper.WaitAll(tasks);')
	writer:endBlock()

	for _, v in ipairs(packages) do
		local namespaceName = v
	    
	    if settings.packageName~=nil and settings.packageName~='' then
	        namespaceName = settings.packageName..'.'..namespaceName;
	    end
		writer:writeln('%s.%sBinder.BindAll();', namespaceName, v)
	end
	writer:endBlock()--function
	writer:endBlock()--class
	writer:endBlock()--namespace

	writer:save(exportCodePath..'/FUIPackageLoader.cs')
end

return {
    onPublishFinish = onPublishFinish,
}