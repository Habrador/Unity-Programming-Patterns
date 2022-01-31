using System;

namespace CommandQueuePattern
{
    public class ThirdCmd : ICommand
    {
        private readonly GameController _owner;

        public Action OnFinished { get; set; }

        public ThirdCmd(GameController owner)
        {
            _owner = owner;
        }

        public void Execute()
        {
            // activate gameobject
            _owner.thirdPopup.gameObject.SetActive(true);

            // listen to its onClose event 
            _owner.thirdPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.thirdPopup.onClose -= OnClose;

            // deactivate gameobject
            _owner.thirdPopup.gameObject.SetActive(false);

            // rise the OnFinished event to say we're done with this command
            OnFinished?.Invoke();
        }
    }
}