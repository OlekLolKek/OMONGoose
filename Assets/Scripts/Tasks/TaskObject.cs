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

        private Canvas _canvas;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _canvas = FindObjectOfType<Canvas>();
        }

        #endregion


        #region Methods

        public void Switch()
        {
            if (!TaskPanel)
            {
                TaskPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTask>();
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