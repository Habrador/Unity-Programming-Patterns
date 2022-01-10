using System;

namespace CommandQueuePattern
{
    public class FirstCmd : ICommand
    {
        private readonly GameController _owner;

        public Action OnFinished { get; set; }

        public FirstCmd(GameController owner)
        {
            _owner = owner;
        }

        public void Execute()
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
            OnFinished?.Invoke();
        }
    }
}