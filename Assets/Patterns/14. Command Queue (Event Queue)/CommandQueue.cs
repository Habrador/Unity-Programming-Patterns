using System.Collections.Generic;

namespace CommandQueuePattern
{
    public class CommandQueue 
    {
        // queue of commands
        private readonly Queue<ICommand> _queue;

        // it's true when a command is running
        private bool _isPending;

        public CommandQueue()
        {
            // create a queue
            _queue = new Queue<ICommand>();

            // no command is running
            _isPending = false;
        }

        public void Enqueue(ICommand cmd)
        {
            // add a command
            _queue.Enqueue(cmd);

            // if no command is running, start to execute commands
            if (!_isPending)
                DoNext();
        }

        public void DoNext()
        {
            // if queue is empty, do nothing.
            if (_queue.Count == 0)
                return;

            // get a command
            var cmd = _queue.Dequeue();
            // setting _isPending to true means this command is running
            _isPending = true;
            // listen to the OnFinished event
            cmd.OnFinished += OnCmdFinished;
            // execute command
            cmd.Execute();
        }

        private void OnCmdFinished()
        {
            // current command is finished
            _isPending = false;

            // run the next command
            DoNext();
        }
    }
}