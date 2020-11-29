namespace OMONGoose
{
    public class InteractInitialization : IInitializable
    {
        #region Fields

        private readonly InteractionSwitch _switch;

        #endregion

        public InteractInitialization()
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