using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.Menu
{
    public class MainMenu : _MenuState
    {
        //Specific for this state
        public void JumpToSettings()
        {
            menuController.SetActiveState(MenuController.MenuState.Settings);
        }

        public void JumpToHelp()
        {
            menuController.SetActiveState(MenuController.MenuState.Help);
        }

        public void QuitGame()
        {
            menuController.QuitGame();
        }
    }
}
