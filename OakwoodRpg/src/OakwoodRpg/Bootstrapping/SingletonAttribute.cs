﻿using Microsoft.Extensions.DependencyInjection;

namespace OakwoodRpg.Bootstrapping;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class SingletonAttribute : ServiceAttribute
{
    public SingletonAttribute(Type? serviceType = null) : base(ServiceLifetime.Singleton, serviceType)
    {
    }
}