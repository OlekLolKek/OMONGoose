namespace OMONGoose
{
    public sealed class InputInitializator
    {
        public InputInitializator(MainController mainController, InputData inputData, UILinks _links)
        {
            var inputModel = new InputModel(inputData.inputStruct);

            mainController.AddUpdatable(new InputController(inputModel, _links));
        }
    }
}