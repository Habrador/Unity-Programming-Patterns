using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Animal
{
    public class Mammal : Animal
    {
        //This is the Type Object
        private IFlyingType flyingType;

        public Mammal(string name, bool canFly)
        {
            this.name = name;

            this.flyingType = canFly ? new ICanFly() as IFlyingType : new ICantFly();
        }

        public override void Talk()
        {
            string canFlyString = flyingType.CanIFly() ? "can" : "can't";

            Debug.Log($"Hello this is {name}, I'm a mammal, and I {canFlyString} fly!");
        }
    }
}
