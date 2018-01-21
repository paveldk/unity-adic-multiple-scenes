namespace Assets.Scripts.Containers
{
    using Adic;
    using Adic.Container;
    using Assets.Scripts.Interfaces.FirstScene;
    using Assets.Scripts.Services.FirstScene;
    using UnityEngine;

    class FirstSceneContainer : ContextRoot
    {
        public override void SetupContainers()
        {
            IInjectionContainer container = new InjectionContainer()
                .RegisterExtension<UnityBindingContainerExtension>()
                .RegisterExtension<SharedContainerExtension>();

            container
                .Bind<IFirstSceneNetworkService>().ToSingleton<FirstSceneNetworkService>()
                .Bind<IFirstScenePlayerService>().ToSingleton<FirstScenePlayerService>();

            this.AddContainer(container);
        }

        public override void Init()
        {
        }
    }
}
