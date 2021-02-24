using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    //The class that "decorates" the car class
    public abstract class _CarExtras : _Car
    {
        protected int howMany;
    }
}
