using System;
using UnityEngine;


namespace OMONGoose
{
    internal sealed class MobileInput : IUserInputProxy
    {
        public event Action<float> OnAxisChanged;
        
        public void GetAxis()
        {
            Debug.Log("Нажали кнопку, видимо, на экране телефона");
        }
    }
}