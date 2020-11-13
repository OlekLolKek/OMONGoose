using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public class MainController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _taskRoot;
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
            
            var inputInitialization = new InputInitialization();
            var playerInitialization = new PlayerInitialization(playerFactory);
            var taskInitialization = new TaskInitialization(_taskRoot);
            var interactInitialization = new InteractInitialization();
            
            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);
            _controllers.Add(taskInitialization);
            _controllers.Add(interactInitialization);
            
            Camera camera = playerInitialization.GetCamera();
            
            _controllers.Add(new InputController(inputInitialization.GetInputKeyboard(), inputInitialization.GetInputMouse(), 
                inputInitialization.GetInputInteract(), inputInitialization.GetInputSave(), inputInitialization.GetInputLoad()));
            _controllers.Add(new MoveController(inputInitialization.GetInputKeyboard(), interactInitialization.GetInteractionSwitch(), 
                playerInitialization.GetCharacterController(), playerInitialization.GetTransform(), playerInitialization.GetAnimator(), 
                _data.PlayerData));
            _controllers.Add(new TaskController(taskInitialization.GetTasks(), _data.TaskData, _context));
            _controllers.Add(new CameraController(inputInitialization.GetInputMouse(), interactInitialization.GetInteractionSwitch(),
                playerInitialization.GetCharacterController().transform,
                _data.PlayerData, camera.transform));
            _controllers.Add(new InteractController(inputInitialization.GetInputInteract(), interactInitialization.GetInteractionSwitch(), 
                camera.transform, _context.CrosshairView));
            _controllers.Add(new CursorController(interactInitialization.GetInteractionSwitch()));
            _controllers.Add(new SaveController(inputInitialization.GetInputLoad(), inputInitialization.GetInputSave(), 
                saveDataRepository, playerFactory));
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