local baseClass = {}
baseClass.__index = baseClass
function baseClass:ctor()
end

function baseClass:isClass()
    return self._className ~= nil
end


function class(className, parent)
    local clazz = {}
    clazz._className = className
    if parent == nil then
        parent = baseClass
    end
    setmetatable(clazz, parent)
    clazz.__index = clazz
    clazz.new = function(...)
        local instance = {}
        instance.super = parent
        instance.class =  clazz
        setmetatable(instance, clazz)
        instance:ctor(...)
        return instance
    end

    return clazz
end

function clone(t)
    local result = nil
    
    local ttype = type(t)

    if ttype == "table" then
        if t.__clone ~= nil then
            return t.__clone
        end
        result = {}
        t.__clone = result
        for k, v in pairs(t) do
            if k ~= "__clone" then
                result[k] = clone(v)
            end
        end
        t.__clone = nil
    else
        result = t
    end
    
    return result
end

function dump(label, t, output, layer)
    if output == nil then
        output = {
            buffer = {}
        }
        if t == nil then
            t = label
            label = "value"
        end
        function output:insertAll(...)
            local params = table.pack(...)
            for _, v in ipairs(params) do
                if type(v) == "string" then
                    table.insert(self.buffer, v)
                end
            end
        end
        function output:print()
            fprint(table.concat(self.buffer))
        end
        output:insertAll("local ")
        dump(label, t, output, 0)
        output:print()
        return
    end
    
    local ttype = type(t)
    for i = 1, layer do
        output:insertAll("\t")
    end
    if ttype == "table" then
        if t.__dumping then
            output:insertAll(label, " = ", tostring(t))
            return
        end
        t.__dumping = true
        output:insertAll(label, " = {\n")
        for k, v in pairs(t) do
            if k ~= "__dumping" then
                dump(k, v, output, layer + 1)
                output:insertAll(",\n")
            end
        end
        for i = 1, layer do
            output:insertAll("\t")
        end
        output:insertAll("}")
        t.__dumping = nil
    elseif ttype == "string" then
        output:insertAll(label, " = ", "\"", t, "\"")
    else
        output:insertAll(label, " = ", tostring(t))
        return
    end
end


function string:contains(sub)
    return self:find(sub, 1, true) ~= nil
end

function string:startswith(start)
    return self:sub(1, #start) == start
end

function string:endswith(ending)
    return ending == "" or self:sub(-#ending) == ending
end

function string:replace(old, new)
    local s = self
    local search_start_idx = 1

    while true do
        local start_idx, end_idx = s:find(old, search_start_idx, true)
        if (not start_idx) then
            break
        end

        local postfix = s:sub(end_idx + 1)
        s = s:sub(1, (start_idx - 1)) .. new .. postfix

        search_start_idx = -1 * postfix:len()
    end

    return s
end

function string:insert(pos, text)
    return self:sub(1, pos - 1) .. text .. self:sub(pos)
end