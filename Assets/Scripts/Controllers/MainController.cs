using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


namespace OMONGoose
{
    public class MainController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Data _data;

        //TODO: Разобраться, что за canvas и button и нужны ли они тут вообще (в коде есть, в вебинаре на 20:00 нет)
        [SerializeField] private Transform _canvas;
        [SerializeField] private Button _button;

        private GameContext _links;
        private Controllers _controllers;

        #endregion


        #region UnityMethods

        private void Start()
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization(new MobileInputFactory(_canvas, _button));
            var playerFactory = new PlayerFactory(_data.PlayerData);
            var playerInitialization = new PlayerInitialization(playerFactory);
            var taskFactory = new TaskFactory(_data.TaskData);
            var taskInitialization = new TaskInitialization(taskFactory);
            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);
            _controllers.Add(taskInitialization);
            _controllers.Add(new InputController(inputInitialization.GetInput()));
            _controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), _data.PlayerData));
            //_controllers.Add(new TaskController(taskInitialization.GetTask()));
            //_controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
            _controllers.Initialization();
            

            //TODO: Убрать старый код, если всё будет работать
            //_links = new GameContext();
            //var tasksArray = FindObjectsOfType<TaskObject>();
            //new InitializeController(this, _playerData, _inputData, _taskData, tasksArray, _links);
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