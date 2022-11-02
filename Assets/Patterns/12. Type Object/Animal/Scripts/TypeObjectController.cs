using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Animal
{
    //Main class to illustrate the Type object pattern
    public class TypeObjectController : MonoBehaviour
    {
        void Start()
        {
            Bird ostrich = new Bird("ostrich", canFly: false);
            
            Bird pigeon = new Bird("pigeon", canFly: true);

            Mammal rat = new Mammal("rat", canFly: false);

            Mammal bat = new Mammal("bat", canFly: true);

            Fish flyingFish = new Fish("flying fish", canFly: true);

            Fish goldFish = new Fish("goldfish", canFly: false);


            ostrich.Talk();

            pigeon.Talk();

            rat.Talk();

            bat.Talk();

            flyingFish.Talk();

            goldFish.Talk();
        }
    }
}
