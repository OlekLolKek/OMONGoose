namespace OMONGoose
{
    public class InteractModel : IInitializable
    {
        #region Fields

        private readonly InteractionSwitch _switch;

        #endregion

        public InteractModel()
        {
            _switch = new InteractionSwitch();
        }

        public void Initialization()
        {
        }

        public InteractionSwitch GetInteractionSwitch()
        {
            return _switch;
        }
    }
}