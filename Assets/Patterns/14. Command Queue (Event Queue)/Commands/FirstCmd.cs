using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandQueuePattern
{
    public class FirstCmd : CommandBase
    {
        private readonly GameController _owner;

        public override bool IsFinished { get; protected set; } = false;

        public FirstCmd(GameController owner)
        {
            _owner = owner;
        }

        public override void Execute()
        {
            // activate gameobject
            _owner.firstPopUp.gameObject.SetActive(true);
            
            // listen to its onClose event 
            _owner.firstPopUp.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.firstPopUp.onClose -= OnClose;

            // deactivate gameobject
            _owner.firstPopUp.gameObject.SetActive(false);

            // rise the OnFinished event to say we're done with this command
            CallOnFinished();
            IsFinished = true;
        }
    }
}