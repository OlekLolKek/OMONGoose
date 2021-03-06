﻿using System;
using UnityEngine;


namespace OMONGoose
{
    public sealed class PCInputVertical : IInputAxisChangeable
    {
        public event Action<float> OnAxisChanged = delegate(float f) {  };

        public void GetAxis()
        {
            OnAxisChanged.Invoke(Input.GetAxisRaw(AxisManager.VERTICAL));
        }
    }
}