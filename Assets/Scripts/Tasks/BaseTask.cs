using System;
using UnityEngine;


namespace OMONGoose
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class BaseTask : MonoBehaviour
    {
        #region Fields

        public delegate void CompletedTaskChange();
        public event CompletedTaskChange CompletedTask;
        
        [HideInInspector] public RoomNames RoomName;
        [HideInInspector] public bool IsDone;

        [Tooltip("The AudioClips Scriptable Object.")]
        [SerializeField] protected AudioClipsData _audioClips;
        protected AudioSource _audioSource;
        protected Canvas _canvas;
        protected Vector3 _normalSize = new Vector3(1.0f, 1.0f, 1.0f);
        protected readonly float _tweenTime = 0.2f;
        protected float _progress = 0.0f;
        protected float _maxProgress;

        #endregion


        #region Methods

        public virtual void Initialize(RoomNames roomName, Canvas canvas)
        {
            LeanTween.scale(gameObject, _normalSize, _tweenTime);
            RoomName = roomName;
            _canvas = canvas;
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _audioClips.AudioClips.WindowAppear;
            _audioSource.Play();
        }

        public virtual void Deactivate()
        {
            LeanTween.scale(gameObject, Vector3.zero, _tweenTime);
            _audioSource.clip = _audioClips.AudioClips.WindowDisappear;
            _audioSource.Play();
            Destroy(gameObject, _tweenTime);
        }

        protected void Completed()
        {
            IsDone = true;
            _audioSource.clip = _audioClips.AudioClips.TaskDone;
            _audioSource.Play();
            CompletedTask?.Invoke();
        }

        #endregion
    }
}