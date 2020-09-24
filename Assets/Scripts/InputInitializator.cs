namespace OMONGoose
{
    public sealed class InputInitializator
    {
        public InputInitializator(MainController mainController)
        {
            mainController.AddUpdatable(new InputController());
        }
    }
}