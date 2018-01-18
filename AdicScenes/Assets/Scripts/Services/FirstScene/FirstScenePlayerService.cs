namespace Assets.Scripts.Services.FirstScene
{
    using Adic;
    using Assets.Scripts.Interfaces.FirstScene;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class FirstScenePlayerService : IFirstScenePlayerService
    {
        [Inject]
        private IFirstSceneNetworkService firstSceneNetworkService;

        // this will be called after the injection completes
        [Inject]
        private void PostConstruct()
        {
            this.firstSceneNetworkService.CheckNetwork();
            this.CheckPlayer();
        }

        public void CheckPlayer()
        {
            Debug.Log("Checking player in first scene");

            SceneManager.LoadScene("SecondScene");
        }
    }
}
