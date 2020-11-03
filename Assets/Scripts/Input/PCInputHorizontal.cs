using System;
using UnityEngine;


namespace OMONGoose
{
    public class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> OnAxisChanged = delegate(float f) {  };

        public void GetAxis()
        {
            OnAxisChanged.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }
    }
}