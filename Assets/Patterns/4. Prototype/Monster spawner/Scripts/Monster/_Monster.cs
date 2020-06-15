using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.MonsterSpawner
{
    //Monster parent class
    public abstract class _Monster
    {
        //This method implements the Prototype design pattern
        public abstract _Monster Clone();

        public abstract void Talk();
    }
}
