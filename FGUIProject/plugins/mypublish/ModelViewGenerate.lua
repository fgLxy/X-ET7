local function onPublish(handler, path, classes)
    local settings = handler.project:GetSettings("Publish").codeGeneration
    local codePkgName = handler:ToFilename(handler.pkg.name); --convert chinese to pinyin, remove special chars etc.

    local exportCodePath = path..'/ModelView/Client/FUI/'..codePkgName
    local namespaceName = codePkgName
    
    if settings.packageName~=nil and settings.packageName~='' then
        namespaceName = settings.packageName..'.'..namespaceName;
    end

    handler:SetupCodeFolder(exportCodePath, "cs") --check if target folder exists, and delete old files

    local getMemberByName = settings.getMemberByName

    local classCnt = classes.Count
    local writer = CodeWriter.new()

    for i=0,classCnt-1 do
        local classInfo = classes[i]
        local members = classInfo.members
        writer:reset()

        writer:writeln('using FairyGUI;')
        writer:writeln('using %s;', namespaceName)
        writer:writeln()
        writer:writeln('namespace ET.Client')
        writer:startBlock()
        writer:writeln('[ComponentOf(typeof(FUIEntity))]')
        writer:writeln('public class %sGetter : Entity, IAwake', classInfo.className)
        writer:startBlock()

        writer:writeln('private %s _ui;', classInfo.className)
        writer:writeln()
        writer:writeln('public %s UI => _ui ?? (%s)this.GetParent<FUIEntity>().GComponent;', classInfo.className, classInfo.className)

        writer:endBlock() --class
        writer:endBlock() --namespace

        writer:save(exportCodePath..'/'..classInfo.className..'Getter.cs')
    end
end

local function onPublishFinish(handler, path)
    local settings = handler.project:GetSettings("Publish").codeGeneration

    local packagesCSharp  = handler.project.allPackages
    local exportCodePath = path..'/ModelView/Client/FUI/'
    handler:SetupCodeFolder(exportCodePath, "cs")
    local panels = {}

    local count = packagesCSharp.Count
    for i=0,count - 1 do
        local pkg = packagesCSharp[i]
        local items = pkg.items
        local itemCount = items.Count
        for itemIndex=0,itemCount - 1 do
            if items[itemIndex].type == 'component' and items[itemIndex].exported and items[itemIndex].name:endswith('Panel') then
                table.insert(panels, items[itemIndex])
            end
        end
    end

    local writer = CodeWriter.new()

    

    writer:writeln()
    writer:writeln('namespace ET.Client')
    writer:startBlock()

    writer:writeln('public enum PanelId')
    writer:startBlock()

    writer:writeln('Invalid = 0,')
    for k, v in ipairs(panels) do
        writer:writeln('%s = %s,', v.name, k)
    end
    writer:endBlock()
    writer:endBlock()

    writer:save(exportCodePath..'/PanelId.cs')
end

return {
    onPublish = onPublish,
    onPublishFinish = onPublishFinish,
}