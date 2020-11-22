using UnityEngine;


namespace OMONGoose
{
    public class MainController : MonoBehaviour
    {
        #region Fields

        [Tooltip("The root Game Object for all the Task Objects.")]
        [SerializeField] private Transform _taskRoot;
        [Tooltip("The Data Scriptable Object.")]
        [SerializeField] private Data _data;

        private GameContext _context;
        private Controllers _controllers;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _context = new GameContext();
            
            var playerFactory = new PlayerFactory(_data.PlayerData);
            var saveDataRepository = new SaveDataRepository();
            
            var inputModel = new InputModel();
            var playerModel = new PlayerModel(playerFactory);
            var taskModel = new TaskModel(_taskRoot);
            var interactModel = new InteractModel();

            _controllers = new Controllers();

            Camera camera = playerModel.GetCamera();
            
            _controllers.Add(new InputController(inputModel.GetInputKeyboard(), inputModel.GetInputMouse(), 
                inputModel.GetInputInteract(), inputModel.GetInputSave(), inputModel.GetInputLoad(), inputModel.GetInputMap()));
            _controllers.Add(new MoveController(inputModel.GetInputKeyboard(), interactModel.GetInteractionSwitch(), 
                playerModel.GetCharacterController(), playerModel.GetTransform(), playerModel.GetAnimator(), 
                _data.PlayerData));
            _controllers.Add(new TaskController(taskModel, _data.TaskData, _context));
            _controllers.Add(new CameraController(inputModel.GetInputMouse(), interactModel.GetInteractionSwitch(),
                playerModel.GetCharacterController().transform,
                _data.PlayerData, camera.transform));
            _controllers.Add(new InteractController(inputModel.GetInputInteract(), interactModel.GetInteractionSwitch(), 
                camera.transform, _context.CrosshairView));
            _controllers.Add(new CursorController(interactModel.GetInteractionSwitch()));
            _controllers.Add(new SaveController(inputModel.GetInputLoad(), inputModel.GetInputSave(), 
                saveDataRepository, playerFactory, camera.transform, taskModel));
            _controllers.Add(new MinimapController(_context.MinimapView, playerFactory.GetTransform(), inputModel.GetInputMap()));
            
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }

        #endregion
    }
}