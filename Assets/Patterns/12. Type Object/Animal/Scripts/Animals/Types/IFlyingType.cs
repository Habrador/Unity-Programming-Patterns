using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Animal
{
    //Defines the Type Object if whatever implements it can fly
    public interface IFlyingType
    {
        bool CanIFly();        
    }
}
