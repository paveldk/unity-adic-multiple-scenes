namespace Assets.Scripts.Services.ThirdScene
{
    using Adic;
    using Assets.Scripts.Interfaces.FirstScene;
    using Assets.Scripts.Interfaces.ThirdScene;
    using UnityEngine;

    public class ThirdSceneEndGameService : IThirdSceneEndGameService
    {
        // This is currently not possible as this dependency is declared in the first scene!!!
        [Inject]
        private IFirstSceneNetworkService firstSceneNetworkService;

        // This SHOULD NOT be possible as this service is declared in the second scene container and it should not persist between scenes
        //[Inject]
        //private ISecondSceneDamageService secondSceneDamageService;

        [Inject]
        private void PostConstruct()
        {
            this.EndGame();
        }

        public void EndGame()
        {
            this.firstSceneNetworkService.CheckNetwork();
            Debug.Log("Ending game in third scene");
        }
    }
}
