using System.Collections;
using UnityEngine;

namespace CommandQueuePattern
{
    public class GameController : MonoBehaviour
    {
        public Popup firstPopUp, secondPopup, thirdPopup;

        private CommandQueue _commandQueue;

        private void Start()
        {
            // create a command queue
            _commandQueue = new CommandQueue();

            // add commands after a period of time
            StartCoroutine(StartCommandsCr());
        }

        private IEnumerator StartCommandsCr()
        {
            // wait for 2 seconds
            yield return new WaitForSeconds(2f);

            // add commands
            _commandQueue.Enqueue(new FirstCmd(this));
            _commandQueue.Enqueue(new SecondCmd(this));
            _commandQueue.Enqueue(new ThirdCmd(this));
        }
    }
}
