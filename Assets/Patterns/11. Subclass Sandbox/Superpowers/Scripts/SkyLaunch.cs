using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubclassSandbox.Superpowers
{
    //Child class that defines a single superpower behavior
    public class SkyLaunch : Superpower
    {
        public override void Activate()
        {
            PlaySound("Launch sound");
            SpawnParticles("Dust");
            Move("The sky");
        }
    }
}
