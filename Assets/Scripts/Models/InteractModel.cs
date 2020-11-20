namespace OMONGoose
{
    public class InteractModel 
    {
        #region Fields

        private readonly InteractionSwitch _switch;

        #endregion

        public InteractModel()
        {
            _switch = new InteractionSwitch();
        }

        public InteractionSwitch GetInteractionSwitch()
        {
            return _switch;
        }
    }
}