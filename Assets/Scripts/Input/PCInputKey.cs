using System;
using UnityEngine;


namespace OMONGoose
{
    public class PCInputKey : IInputKeyPressable
    {
        public event Action<bool> OnKeyPressed = delegate(bool b) {  };
        private KeyCode _keyCode;

        public PCInputKey(KeyCode keyCode)
        {
            _keyCode = keyCode;
        }
        
        public void GetKey()
        {
            if (Input.GetKeyDown(_keyCode))
            {
                OnKeyPressed.Invoke(true);
            }
        }
    }
}