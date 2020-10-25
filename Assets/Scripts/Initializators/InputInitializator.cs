namespace OMONGoose
{
    public sealed class InputInitializator
    {
        public InputInitializator(MainController mainController, InputData inputData, GameContext _links)
        {
            var inputModel = new InputModel(inputData.InputStruct);

            mainController.AddUpdatable(new InputController(inputModel, _links));
        }
    }
}