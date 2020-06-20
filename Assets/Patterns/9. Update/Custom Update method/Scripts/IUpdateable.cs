using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Update.CustomUpdateMethod
{
    //Interface for base class for custom Update method
    public interface IUpdateable
    {
        //This is the custom update method
        void OnUpdate(float dt);
    }
}
