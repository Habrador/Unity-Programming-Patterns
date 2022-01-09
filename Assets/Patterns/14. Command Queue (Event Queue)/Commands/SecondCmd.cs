namespace CommandQueuePattern
{
    public class SecondCmd : CommandBase
    {
        private readonly GameController _owner;

        public override bool IsFinished { get; protected set; } = false;

        public SecondCmd(GameController owner)
        {
            _owner = owner;
        }

        public override void Execute()
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
            CallOnFinished();
            IsFinished = true;
        }
    }
}