using Adic;
using Adic.Container;
using Assets.Scripts.Interfaces.SecondScene;
using Assets.Scripts.Services.SecondScene;

public class SecondSceneContainer : ContextRoot
{
    public override void SetupContainers()
    {
        IInjectionContainer container = new InjectionContainer()
            .RegisterExtension<UnityBindingContainerExtension>()
            .RegisterExtension<SharedContainerExtension>();

        container
            .Bind<ISecondSceneDamageService>().ToSingleton<SecondSceneDamageService>();

        this.AddContainer(container);
    }

    public override void Init()
    {
    }
}
