using UnityEngine;


namespace OMONGoose
{
    public class BaseTaskPanelController
    {
        public bool IsDone { get; private set; }
        
        public delegate void CompletedTaskChange();
        public event CompletedTaskChange CompletedTask;
        public bool IsActive;
        
        protected BaseTaskView _taskViewPanel;
        protected readonly float _tweenTime = 0.2f;
        protected float _progress;
        protected float _maxProgress;
        private readonly GameObject _taskPanelPrefab;
        private readonly Canvas _canvas;
        
        
        protected BaseTaskPanelController(Canvas canvas, GameObject taskPanelPrefab)
        {
            _canvas = canvas;
            _taskPanelPrefab = taskPanelPrefab;
        }
        
        public void Switch()
        {
            if (!_taskViewPanel)
            {
                Activate();
            }
            else
            {
                Deactivate();
            }
        }

        protected virtual void Activate()
        {
            _taskViewPanel = Object.Instantiate(_taskPanelPrefab, _canvas.transform).GetComponent<BaseTaskView>();
            _taskViewPanel.Initialize();
            _taskViewPanel.CompletedTask += OnTaskCompleted;
            IsActive = true;
        }

        protected virtual void Deactivate()
        {
            if (_taskViewPanel.IsDone)
            {
                IsDone = true;
            }

            _progress = 0.0f;
            IsActive = false;
            _taskViewPanel.CompletedTask -= OnTaskCompleted;
            _taskViewPanel.Deactivate();
        }

        private void OnTaskCompleted()
        {
            CompletedTask.Invoke();
        }
    }
}