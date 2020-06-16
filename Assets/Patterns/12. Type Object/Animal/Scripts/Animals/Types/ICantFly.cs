using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Animal
{
    //This type can't fly
    public class ICantFly : IFlyingType
    {
        public bool CanIFly()
        {
            return false;
        }
    }
}
