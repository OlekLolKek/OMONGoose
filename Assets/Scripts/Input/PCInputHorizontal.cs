using System;
using UnityEngine;


namespace OMONGoose
{
    public class PCInputHorizontal : IInputAxisChangeable
    {
        public event Action<float> OnAxisChanged = delegate(float f) {  };

        public void GetAxis()
        {
            OnAxisChanged.Invoke(Input.GetAxisRaw(AxisManager.HORIZONTAL));
        }
    }
}