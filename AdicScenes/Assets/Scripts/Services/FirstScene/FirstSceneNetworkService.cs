namespace Assets.Scripts.Services.FirstScene
{
    using Assets.Scripts.Interfaces.FirstScene;
    using UnityEngine;

    public class FirstSceneNetworkService : IFirstSceneNetworkService
    {
        public void CheckNetwork()
        {
            Debug.Log("Checking network in first scene");
        }
    }
}
