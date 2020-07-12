﻿using Autofac;

namespace Core.IoC
{
    public static class DependencyResolver
    {
        private static ServiceLocator _servicelocator;
        private static ILifetimeScope _container;

        public static IServiceLocator ServiceLocator => _servicelocator;
        public static ILifetimeScope Container => _container;


        public static void SetContainer(ILifetimeScope container)
        {
            _container = container;
            _servicelocator = new ServiceLocator(container);
        }
    }
}