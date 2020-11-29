using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Random = UnityEngine.Random;


namespace OMONGoose
{
    public class AsteroidsTask : BaseTask, IExecutable
    {
        #region Fields

        [SerializeField] private Asteroid _asteroidPrefab;
        [SerializeField] private AnimationClip _clip;

        private readonly List<Asteroid> _asteroids = new List<Asteroid>();
        private Animator _animator;
        private Image _thisImage;
        private Vector2 _sizeDelta;
        private Vector2 _direction;
        private float _asteroidSpeed = 2.0f;
        private float _canvasScaleFactor;
        private int _asteroidsCount = 10;
        private float _maxRight;
        private float _maxLeft;
        private float _maxUp;
        private float _maxDown;
        private float _startOffset = 150.0f;

        #endregion


        #region Methods

        //TODO: Поменять Update на Execute и вызывать его из другого места
        public void Execute(float deltaTime)
        {
            foreach (var asteroid in _asteroids)
            {
                asteroid.Execute(deltaTime);
            }
        }

        public override void Initialize(RoomNames roomName, Canvas canvas)
        {
            base.Initialize(roomName, canvas);

            _thisImage = GetComponent<Image>();
            _maxProgress = 10.0f;
            
            _audioSource = GetComponent<AudioSource>();
            _sizeDelta = _thisImage.rectTransform.sizeDelta;
            _canvasScaleFactor = _canvas.scaleFactor;

            _maxLeft = Screen.width / 2 - _sizeDelta.x * _canvasScaleFactor / 2;
            _maxRight = Screen.width / 2 + _sizeDelta.x * _canvasScaleFactor / 2;
            _maxDown = Screen.height / 2 - _sizeDelta.y * _canvasScaleFactor / 2;
            _maxUp = Screen.height / 2 + _sizeDelta.y * _canvasScaleFactor / 2;

            _startOffset *= _canvasScaleFactor / 2;
            for (int i = 0; i < _asteroidsCount; i++)
            {
                var asteroid = Instantiate(
                    _asteroidPrefab,
                    new Vector3(
                        Random.Range(_maxLeft + _startOffset, _maxRight - _startOffset),
                        Random.Range(_maxDown + _startOffset, _maxUp - _startOffset)),
                    Quaternion.identity,
                    _canvas.transform
                ).GetComponent<Asteroid>();

                _asteroids.Add(asteroid);
                var i1 = i;

                _asteroids[i].OnAsteroidDestroyed += DestroyAsteroid;
                _asteroids[i].Initialization(i1, _maxRight, _maxLeft, _maxUp, _maxDown);
            }
        }

        
        private void DestroyAsteroid(int index)
        {
            _progress++;
            if (_progress >= _maxProgress)
            {
                Completed();
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();
            foreach (var asteroid in _asteroids)
            {
                Destroy(asteroid.gameObject);
            }

            _asteroids.Clear();
        }

        #endregion
    }
}