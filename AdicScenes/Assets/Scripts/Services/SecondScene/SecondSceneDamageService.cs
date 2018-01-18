namespace Assets.Scripts.Services.SecondScene
{
    using Adic;
    using Assets.Scripts.Interfaces.FirstScene;
    using Assets.Scripts.Interfaces.SecondScene;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SecondSceneDamageService : ISecondSceneDamageService
    {
        // This is currently not possible as this dependency is declared in the first scene!!!
        //[Inject]
        //private IFirstSceneNetworkService firstSceneNetworkService;

        [Inject]
        private void PostConstruct()
        {
            //this.firstSceneNetworkService.CheckNetwork();
            this.DoDamage();
        }

        public void DoDamage()
        {
            Debug.Log("Doing damage in second scene");

            SceneManager.LoadScene("ThirdScene");
        }
    }
}
