﻿using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class DefaultDependencyFactories : DependencyFactories
    {
        IDictionary<Type, DependencyFactory> all_factories;
        MissingDependencyFactory missing_dependency_factory;

        public DefaultDependencyFactories(IDictionary<Type, DependencyFactory> all_factories,
                                          MissingDependencyFactory missing_dependency_factory)
        {
            this.all_factories = all_factories;
            this.missing_dependency_factory = missing_dependency_factory;
        }

        public DependencyFactory get_factory_that_can_create(Type dependency_type)
        {
            if (all_factories.ContainsKey(dependency_type)) return all_factories[dependency_type];

            return this.missing_dependency_factory(dependency_type);
        }
    }
}