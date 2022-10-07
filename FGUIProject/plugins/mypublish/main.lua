require(PluginPath.."/common")
local autogen = require(PluginPath..'/GenCode_CSharp')
local modelGen = require(PluginPath..'/ModelViewGenerate')
local hotfixGen = require(PluginPath..'/HotfixViewGenerate')
local generates = {
    autogen, modelGen, hotfixGen
}
local pkgs = {}

function ifOnComplete(handler)
    local allComplete = false
    local project = handler.project
    local count = project.allPackages.Count
    for i=0,count-1 do
        local pkg = project.allPackages[i]
        if pkg.name == handler.pkg.name then
            allComplete = true
            break
        end
    end
    if not allComplete then
        return
    end
    for _, v in ipairs(generates) do
        if v.onPublishFinish then
            v.onPublishFinish(handler, handler.exportCodePath)
        end
    end
end

function onPublish(handler)
    if not handler.genCode then return end
    handler.genCode = false --prevent default output

    fprint('Handling gen code in plugin mypublish')

    local settings = handler.project:GetSettings("Publish").codeGeneration
    --CollectClasses(stripeMemeber, stripeClass, fguiNamespace)
    local classes = handler:CollectClasses(settings.ignoreNoname, settings.ignoreNoname, nil)
    handler:SetupCodeFolder(handler.exportCodePath, "cs") --check if target folder exists, and delete old files

    for _, v in ipairs(generates) do
        if v.onPublish then
            v.onPublish(handler, handler.exportCodePath, classes)
        end
    end
    ifOnComplete(handler)
end

function onDestroy()
-------do cleanup here-------
    
end