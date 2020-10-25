using UnityEngine;


namespace OMONGoose
{
    public abstract class BaseTask : MonoBehaviour
    {
        #region Fields

        public RoomNames RoomName;
        public TaskTypes Type;
        
        [HideInInspector] public bool IsDone = false;

        protected TaskController _taskController;
        protected Vector3 _normalSize = new Vector3(1.0f, 1.0f, 1.0f);
        protected float _tweenTime = 0.2f;
        protected float _progress = 0.0f;
        protected float _maxProgress;

        #endregion


        #region Methods

        public virtual void Initialize(TaskController taskController, RoomNames roomName)
        {
            _taskController = taskController;
            LeanTween.scale(gameObject, _normalSize, _tweenTime);
            RoomName = roomName;
        }

        public virtual void Deactivate()
        {
            LeanTween.scale(gameObject, Vector3.zero, _tweenTime);
            Destroy(gameObject, _tweenTime);
        }

        protected void Completed()
        {
            IsDone = true;
            _taskController.CompleteTask();
        }

        #endregion
    }
}