using System.Collections;
using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskObject : MonoBehaviour
    {
        #region Fields

        public TaskTypes Type;
        public BaseTask TaskPanel;
        public bool IsDone = false;

        [SerializeField] private RoomNames RoomName;
        [SerializeField] private GameObject _panelPrefab;

        private TaskController _taskController;
        private Canvas _canvas;

        #endregion


        #region Methods

        public void Initialize(TaskController taskController, Canvas canvas)
        {
            _canvas = canvas;
            _taskController = taskController;
        }

        public void Switch()
        {
            if (!TaskPanel)
            {
                TaskPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTask>();
                TaskPanel.Initialize(_taskController);
                TaskPanel.SetName(RoomName);
            }
            else
            {
                if (TaskPanel.IsDone)
                {
                    IsDone = true;
                }
                TaskPanel.Deactivate();
            }
        }

        #endregion
    }
}