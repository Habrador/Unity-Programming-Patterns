using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.Menu
{
    //This is the parent class to all states
    public class _MenuState : MonoBehaviour
    {
        //Which state is this? You have to manually set it in the inspector (you could also set it from the child)
        public MenuController.MenuState state;


        protected MenuController menuController;
        

        //Dependency injection of the MenuController to make it easier to reference it from each menu
        public void InitState(MenuController menuController)
        {
            this.menuController = menuController;
        }


        //Jump back to the menu before it when we press a back button or escape key
        //You have to manually hook up each back-button to this method
        public void JumpBack()
        {
            menuController.JumpBack();
        }
    }
}
