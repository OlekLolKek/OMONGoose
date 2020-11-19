using System;


namespace OMONGoose
{
    public interface IInputAxisChangeable
    {
        event Action<float> OnAxisChanged;
        void GetAxis();
    }
}