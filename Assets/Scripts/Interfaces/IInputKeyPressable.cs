using System;


namespace OMONGoose
{
    public interface IInputKeyPressable
    {
        event Action<bool> OnKeyPressed;
        void GetKey();
    }
}