using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Animal
{
    //This type can fly
    public class ICanFly : IFlyingType
    {
        public bool CanIFly()
        {
            return true;
        }
    }
}
