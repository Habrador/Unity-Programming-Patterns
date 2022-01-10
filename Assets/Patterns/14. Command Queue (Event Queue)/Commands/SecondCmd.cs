using System;

namespace CommandQueuePattern
{
    public class SecondCmd : ICommand
    {
        private readonly GameController _owner;

        public SecondCmd(GameController owner)
        {
            _owner = owner;
        }

        public Action OnFinished { get; set; }

        public void Execute()
        {
            // activate gameobject
            _owner.secondPopup.gameObject.SetActive(true);

            // listen to its onClose event 
            _owner.secondPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.secondPopup.onClose -= OnClose;

            // deactivate gameobject
            _owner.secondPopup.gameObject.SetActive(false);

            // rise the OnFinished event to say we're done with this command
            OnFinished?.Invoke();
        }
    }
}