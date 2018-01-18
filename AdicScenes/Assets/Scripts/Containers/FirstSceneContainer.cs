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
            // I think this will be needed in order to keep the container persistent between scenes
            DontDestroyOnLoad(this.transform.gameObject);
            
            IInjectionContainer container = new InjectionContainer("main").RegisterExtension<UnityBindingContainerExtension>();

            container
                .Bind<IFirstSceneNetworkService>().ToSingleton<FirstSceneNetworkService>()
                .Bind<IFirstScenePlayerService>().ToSingleton<FirstScenePlayerService>();

            // here we could have another method - AddMainContainer. one application should be able to have only one container and throw exection if another is added.
            // another option is to use some kind of convention - when you pass name "main" for the injection container constructor to auto handle this
            // the main container should also be available as static property for Adic across the scenes??? Bad alternative would be to have a custom service that holds reference to the container and is initialized as part of that container but this will lead to cycle ref
            this.AddContainer(container, false);
        }

        public override void Init()
        {
        }
    }
}
