using System;
using UnityEngine;


namespace OMONGoose
{
    public class PCInputInteract : IInputKeyPressable
    {
        // Я не знаю, как сделать событие, принимающее аргумент типа void, так что пришлось делать через bool
        // В случае с осями Horizontal и Vertical нужно получать значения осей, здесь это не требуется
        // Можно ли как-то избавиться от bool?
        
        public event Action<bool> OnKeyPressed = delegate(bool b) {  };
        
        public void GetKey()
        {
            if (Input.GetKeyDown(AxisManager.INTERACT))
            {
                OnKeyPressed.Invoke(true);
            }
        }
    }
}