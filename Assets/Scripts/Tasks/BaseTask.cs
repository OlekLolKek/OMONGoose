using UnityEngine;


namespace OMONGoose
{
    public abstract class BaseTask : MonoBehaviour
    {
        #region Fields

        public RoomNames RoomName;
        public TaskTypes Type;
        public bool IsActive = false;
        public bool IsDone = false;

        protected TaskController _taskController;
        protected Vector3 _normalSize = new Vector3(1.0f, 1.0f, 1.0f);
        protected float _tweenTime = 0.2f;
        protected float _progress = 0.0f;
        protected float _maxProgress;

        #endregion


        #region Methods

        public virtual void Initialize(TaskController taskController)
        {
            _taskController = taskController;
            IsActive = true;
            LeanTween.scale(gameObject, _normalSize, _tweenTime);
        }

        public virtual void SetName(RoomNames roomName)
        {
            RoomName = roomName;
        }

        public virtual void Deactivate()
        {
            IsActive = false;
            LeanTween.scale(gameObject, Vector3.zero, _tweenTime);
            Destroy(gameObject, _tweenTime);
        }

        protected virtual void Completed()
        {
            ServiceLocator.Resolve<TaskController>().CompleteTask();
        }

        #endregion
    }
}