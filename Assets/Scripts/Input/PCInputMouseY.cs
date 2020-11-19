﻿using System;
using UnityEngine;

namespace OMONGoose
{
    public class PCInputMouseY : IInputAxisChangeable
    {
        public event Action<float> OnAxisChanged = delegate(float f) {  };
        
        public void GetAxis()
        {
            OnAxisChanged.Invoke(Input.GetAxis(AxisManager.MOUSE_Y));
        }
    }
}