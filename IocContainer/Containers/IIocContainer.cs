﻿namespace IocContainer.Containers
{
    public interface IIocContainer
    {
        void Register<TInterface, TImplementation>()
            where TImplementation : TInterface; //Can't force TInterface to actually be an interface here; needs to be in the implementation
        TInterface Resolve<TInterface>();
    }
}