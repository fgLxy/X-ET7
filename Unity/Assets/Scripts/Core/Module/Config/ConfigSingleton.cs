﻿using System;
using System.Collections.Generic;

namespace ET
{
    public interface IConfigCategory
    {
        void Resolve(Dictionary<string, IConfigSingleton> _tables);
        
        void TranslateText(System.Func<string, string, string> translator);
    }

    public interface IConfigSingleton: IConfigCategory, ISingleton
    {
        
    }

    public abstract class ConfigSingleton<T> : ProtoObject, ISingleton where T : ConfigSingleton<T>, new()
    {
        [StaticField]
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance ??= ConfigComponent.Instance.LoadOneConfig(typeof(T)) as T;
            }
        }

        public void Register()
        {
            if (instance != null)
            {
                throw new Exception($"singleton register twice! {typeof(T).Name}");
            }
            instance = (T)this;
        }

        public void Destroy()
        {
            T t = instance;
            instance = null;
            t.Dispose();
        }

        public bool IsDisposed()
        {
            throw new NotImplementedException();
        }

        public override void AfterEndInit()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}