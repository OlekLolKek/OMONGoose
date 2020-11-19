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
            
            //TODO: Переместить изменение состояния курсора в отдельный класс
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            var playerFactory = new PlayerFactory(_data.PlayerData);
            
            var inputInitialization = new InputInitialization();
            var playerInitialization = new PlayerInitialization(playerFactory);
            var taskInitialization = new TaskInitialization(_taskRoot);
            
            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);
            _controllers.Add(taskInitialization);
            Camera camera = playerInitialization.GetCamera();
            _controllers.Add(new InputController(inputInitialization.GetInputKeyboard(), inputInitialization.GetInputMouse(), inputInitialization.GetInputInteract()));
            _controllers.Add(new MoveController(inputInitialization.GetInputKeyboard(), playerInitialization.GetCharacterController(), 
                playerInitialization.GetTransform(), _data.PlayerData));
            _controllers.Add(new TaskController(taskInitialization.GetTasks(), _data.TaskData, _context));
            _controllers.Add(new CameraController(inputInitialization.GetInputMouse(), playerInitialization.GetCharacterController().transform,
                _data.PlayerData, camera.transform));
            _controllers.Add(new InteractController(camera.transform, inputInitialization.GetInputInteract()));
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