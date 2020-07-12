﻿using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Core.Extensions;

namespace Core.IoC
{
    public interface IServiceLocator
    {
        object GetInstance(Type serviceType);
        object GetInstanceWith(Type serviceType, params Parameter[] parameters);
        object GetInstance(Type serviceType, string key);
        IEnumerable<object> GetAllInstances(Type serviceType);
        T GetInstance<T>(params object[] p);
        T GetInstance<T>(string key);
        IEnumerable<T> GetAllInstances<T>();
    }

    public class ServiceLocator : IServiceLocator
    {
        private readonly ILifetimeScope container;

        public ServiceLocator(ILifetimeScope container)
        {
            this.container = container;
        }

        public object GetInstance(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public object GetInstanceWith(Type serviceType, params Parameter[] parameters)
        {
            return container.Resolve(serviceType, parameters);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return container.ResolveNamed(key, serviceType);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return container.Resolve(serviceType) as IEnumerable<object>;
        }

        public T GetInstance<T>(params object[] p)
        {
            var @params = new List<Parameter>();
            p.ForEach(x =>
            {
                var type = x.GetType();
                @params.Add(new TypedParameter(type, x));
                type.GetInterfaces().ForEach(i => @params.Add(new TypedParameter(i, x)));
            });

            return container.Resolve<T>(parameters: @params);
        }

        public T GetInstance<T>(string key)
        {
            return container.ResolveNamed<T>(key);
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            return container.Resolve<IEnumerable<T>>();
        }
    }
}