using System;
using UnityEngine;

namespace OMONGoose
{
    public class CrosshairEvent
    {
        public event Action<bool> OnAxisChanged = delegate(bool b) {  };
        public void ChangeCrosshair()
        {
            OnAxisChanged.Invoke(true);
        }
    }
}