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
        
        protected Vector3 _normalSize = new Vector3(1.0f, 1.0f, 1.0f);
        protected float _tweenTime = 0.2f;
        protected float _progress = 0.0f;
        protected float _maxProgress;

        #endregion


        #region Methods

        public virtual void Initialize(RoomNames roomName)
        {
            IsActive = true;
            LeanTween.scale(gameObject, _normalSize, _tweenTime);
            RoomName = roomName;
        }

        public virtual void Deactivate()
        {
            IsActive = false;
            LeanTween.scale(gameObject, Vector3.zero, _tweenTime);
            Destroy(gameObject, _tweenTime);
        }

        protected void Completed()
        {
            IsDone = true;
            ServiceLocator.Resolve<TaskController>().CompleteTask();
        }

        #endregion
    }
}