using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace OMONGoose
{
    public class AsteroidController : IExecutable
    {
        #region Fields

        public event Action<int> OnAsteroidDestroyed = delegate { };

        private AsteroidView _asteroidView;

        private readonly AnimationClip _animationClip;
        private readonly AudioSource _asteroidAudioSource;
        private readonly Animator _asteroidAnimator;
        private readonly Button _asteroidButton;
        private readonly Image _asteroidImage;
        private readonly Vector2 _direction;
        private readonly float _maxRight;
        private readonly float _maxLeft;
        private readonly float _maxUp;
        private readonly float _maxDown;
        private readonly float _boundsOffset = 50.0f;
        private readonly float _speed = 2.0f;
        private readonly int _index;
        
        private readonly int _explosion = Animator.StringToHash("Explosion");

        #endregion


        public AsteroidController(int index, float maxRight, float maxLeft, 
            float maxUp, float maxDown, float startOffset,
            AsteroidView asteroidPrefab, Canvas canvas)
        {
            _index = index;
            _maxRight = maxRight;
            _maxLeft = maxLeft;
            _maxUp = maxUp;
            _maxDown = maxDown;
            var startOffset1 = startOffset;
            
            _asteroidView = Object.Instantiate(asteroidPrefab.gameObject,
                new Vector3(
                    Random.Range(_maxLeft + startOffset1, _maxRight - startOffset1),
                    Random.Range(_maxDown + startOffset1, _maxUp - startOffset1)),
                Quaternion.identity,
                canvas.transform).
                GetComponent<AsteroidView>();

            _asteroidAudioSource = _asteroidView.GetComponent<AudioSource>();
            _asteroidAnimator = _asteroidView.GetComponent<Animator>();
            _asteroidButton = _asteroidView.GetComponent<Button>();
            _asteroidImage = _asteroidView.GetComponent<Image>();
            _animationClip = _asteroidView.AnimationClip;
            
            _asteroidButton.onClick.AddListener(DestroyAsteroid);

            _speed *= canvas.scaleFactor;
            _direction = new Vector2(
                Random.Range(0, _speed),
                Random.Range(0, _speed)).normalized * _speed;
        }
        
        public void Execute(float deltaTime)
        {
            Move();
        }

        private void Move()
        {
            if (_asteroidView.transform.position.x >= _maxRight - _boundsOffset)
                _asteroidView.transform.Rotate(_asteroidView.transform.forward, 90.0f);

            else if (_asteroidView.transform.position.x <= _maxLeft + _boundsOffset)
                _asteroidView.transform.Rotate(_asteroidView.transform.forward, -90.0f);

            else if (_asteroidView.transform.position.y >= _maxUp - _boundsOffset)
                _asteroidView.transform.Rotate(_asteroidView.transform.forward, 90.0f);

            else if (_asteroidView.transform.position.y <= _maxDown + _boundsOffset)
                _asteroidView.transform.Rotate(_asteroidView.transform.forward, 90.0f);

            _asteroidView.transform.Translate(_direction);
        }

        private void DestroyAsteroid()
        {
            _asteroidAnimator.SetTrigger(_explosion);
            _asteroidButton.interactable = false;
            _asteroidAudioSource.Play();
            AsteroidExplosion().ToObservable().Subscribe();
            OnAsteroidDestroyed.Invoke(_index);
        }

        private IEnumerator AsteroidExplosion()
        {
            yield return new WaitForSeconds(_animationClip.length);
            _asteroidImage.enabled = false;
            _asteroidButton.enabled = false;
        }

        public void DestroyGameObject()
        {
            Object.Destroy(_asteroidView);
        }
    }
}