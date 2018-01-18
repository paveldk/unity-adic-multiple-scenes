using Adic;
using Adic.Container;
using Assets.Scripts.Interfaces.SecondScene;
using Assets.Scripts.Services.SecondScene;
using UnityEngine;

public class SecondSceneContainer : ContextRoot
{
    public override void SetupContainers()
    {
        IInjectionContainer container = new InjectionContainer().RegisterExtension<UnityBindingContainerExtension>();

        // this container should not persist (should be disposed) when changing scene
        container
            .Bind<ISecondSceneDamageService>().ToSingleton<SecondSceneDamageService>();

        this.AddContainer(container);
    }

    public override void Init()
    {
    }
}
