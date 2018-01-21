using Adic;
using Adic.Container;
using Assets.Scripts.Interfaces.ThirdScene;
using Assets.Scripts.Services.ThirdScene;
using UnityEngine;

public class ThirdSceneContainer : ContextRoot
{
    public override void SetupContainers()
    {
        IInjectionContainer container = new InjectionContainer()
            .RegisterExtension<UnityBindingContainerExtension>()
            .RegisterExtension<SharedContainerExtension>();

        // this container should not persist (should be disposed) when changing scene
        container
            .Bind<IThirdSceneEndGameService>().ToSingleton<ThirdSceneEndGameService>();

        this.AddContainer(container);
    }

    public override void Init()
    {
    }
}
