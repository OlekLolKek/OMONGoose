using System;


namespace OMONGoose
{
    //TODO: разобраться, что это вообще такое и зачем и почему
    public interface IUserInputProxy
    {
        event Action<float> OnAxisChanged;
        void GetAxis();
    }
}