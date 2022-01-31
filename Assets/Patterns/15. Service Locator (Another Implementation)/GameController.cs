namespace ServiceLocatorPattern
{
    using UnityEngine;

    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            var firstService = ServiceLocator.Resolve<FirstService>();
            var secondService = ServiceLocator.Resolve<SecondService>();
            var thirdService = ServiceLocator.Resolve<ThirdService>();

            firstService?.SayHi();
            secondService?.SimpleMethod();
            thirdService?.Foo();
        }
    }
}
