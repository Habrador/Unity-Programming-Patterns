using System;
using UnityEngine;

namespace CommandQueuePattern
{
    public class Popup : MonoBehaviour
    {
        public Action onClose;

        public void Close()
        {
            onClose?.Invoke();
        }
    }
}
