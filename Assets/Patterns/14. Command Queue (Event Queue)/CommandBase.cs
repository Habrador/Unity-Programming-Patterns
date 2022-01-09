using System;

namespace CommandQueuePattern
{
    public abstract class CommandBase
    {
        public Action OnFinished { get; set; }

        public abstract void Execute();

        public abstract bool IsFinished { get; protected set; }

        protected void CallOnFinished()
        {
            OnFinished?.Invoke();
        }
    }
}