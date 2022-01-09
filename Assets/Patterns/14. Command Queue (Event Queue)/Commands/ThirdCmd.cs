namespace CommandQueuePattern
{
    public class ThirdCmd : CommandBase
    {
        private readonly GameController _owner;

        public override bool IsFinished { get; protected set; } = false;

        public ThirdCmd(GameController owner)
        {
            _owner = owner;
        }

        public override void Execute()
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
            CallOnFinished();
            IsFinished = true;
        }
    }
}