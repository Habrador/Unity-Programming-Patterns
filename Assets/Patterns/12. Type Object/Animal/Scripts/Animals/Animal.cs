using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Animal
{
    //Parent animal class
    public abstract class Animal
    {
        protected string name;

        public abstract void Talk();
    }
}
