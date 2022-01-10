using System;

namespace CommandQueuePattern
{
    public interface ICommand
    {
        Action OnFinished { get; set; }

        void Execute();
    }
}