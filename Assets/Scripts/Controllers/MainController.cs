using UnityEngine;
using System.Collections.Generic;


namespace OMONGoose
{
    public class MainController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerData _playerData;
        [SerializeField] private InputData _inputData;
        [SerializeField] private TaskData _taskData;

        private GameContext _links;
        private List<IUpdatable> _iUpdatebles = new List<IUpdatable>();

        #endregion


        #region UnityMethods

        private void Start()
        {
            _links = new GameContext();
            var tasksArray = FindObjectsOfType<TaskObject>();
            new InitializeController(this, _playerData, _inputData, _taskData, tasksArray, _links);
        }

        private void Update()
        {
            for (int i = 0; i < _iUpdatebles.Count; i++)
            {
                _iUpdatebles[i].UpdateTick();
            }
        }

        #endregion


        #region Methods

        public void AddUpdatable(IUpdatable iUpdatable)
        {
            _iUpdatebles.Add(iUpdatable);
            ServiceLocator.SetService(iUpdatable);
        }

        #endregion
    }
}