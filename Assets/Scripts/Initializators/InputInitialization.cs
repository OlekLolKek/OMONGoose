using UnityEngine.UI;


namespace OMONGoose
{
    internal sealed class InputInitialization : IInitializable
    {
        #region Fields

        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        //TODO: разобраться, что за button и MobileInput
        private Button _button;
        private MobileInput _mobileInput;

        #endregion
        
        public InputInitialization(IMobileInputFactory mobileInputFactory)
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _button = mobileInputFactory.Create();
            _mobileInput = new MobileInput();
            _button.onClick.AddListener(_mobileInput.GetAxis);
        }

        public void Initialization()
        {
            //TODO: Зачем
        }

        //TODO: загуглить кортежи
        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal,
                _pcInputVertical);
            return result;
        }

        ~InputInitialization()
        {
            _button.onClick.RemoveListener(_mobileInput.GetAxis);
        }
        
    }
}