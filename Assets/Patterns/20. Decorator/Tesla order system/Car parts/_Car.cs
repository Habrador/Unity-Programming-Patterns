using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    //The class we want to add behavior to
    public abstract class _Car 
    {
        protected string description;

        public abstract string GetDescription();

        public abstract float Cost();
    }
}
