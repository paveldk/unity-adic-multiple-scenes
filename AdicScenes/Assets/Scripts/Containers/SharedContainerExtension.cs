using Adic.Container;
using Adic.Injection;
using Adic;
using Assets.Scripts.Interfaces.FirstScene;
using Assets.Scripts.Services.FirstScene;
using System;
using System.Linq;
using Adic.Binding;
using System.Collections.Generic;

public class SharedContainerExtension : IContainerExtension
{
    private static IInjectionContainer sharedContainer;

    public void Init(IInjectionContainer container)
    {
    }

    public void OnRegister(IInjectionContainer container)
    {
        container.beforeResolve += this.BeforeResolve;
    }

    public void OnUnregister(IInjectionContainer container)
    {
        container.beforeResolve -= this.BeforeResolve;
    }

    private static IInjectionContainer CreateSharedContainer()
    {
        var container = new InjectionContainer()
            .RegisterExtension<UnityBindingContainerExtension>();

        container
            .Bind<IFirstSceneNetworkService>().ToSingleton<FirstSceneNetworkService>()
            .Bind<IFirstScenePlayerService>().ToSingleton<FirstScenePlayerService>();

        return container;
    }

    private bool BeforeResolve(IInjector source, Type type, InjectionMember member, object parentInstance, object identifier, ref object resolutionInstance)
    {
        if (sharedContainer == null)
        {
            sharedContainer = CreateSharedContainer();
        }

        IList<BindingInfo> bindings;

        if (type.IsInterface)
        {
            bindings = sharedContainer.GetBindingsFor(type);
        } else
        {
            bindings = sharedContainer.GetBindingsTo(type);
        }

        if (bindings == null || !bindings.Any())
        {
            return true;
        }

        resolutionInstance = sharedContainer.Resolve(type);

        return false;
    }
}
