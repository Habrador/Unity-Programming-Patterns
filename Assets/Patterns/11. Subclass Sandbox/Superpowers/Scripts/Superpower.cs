using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubclassSandbox.Superpowers
{
    //Superpower parent class which defines all superpowers we can combine in the child classes
    public abstract class Superpower
    {
        //This is the sandbox method in which the children combine superpowers
        public abstract void Activate();

        //Different superpowers
        protected void Move(string where)
        {
            Debug.Log($"Moving towards {where}");
        }

        protected void PlaySound(string sound)
        {
            Debug.Log($"Playing sound {sound}");
        }

        protected void SpawnParticles(string particles)
        {
            Debug.Log($"Firing {particles}");
        }
    }
}
