using UnityEngine;

namespace ServiceLocatorPattern
{
    public class FirstService : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Unregister(this);
        }

        public void SayHi()
        {
            Debug.Log("Hi, this is the " + nameof(FirstService));
        }
    }
}