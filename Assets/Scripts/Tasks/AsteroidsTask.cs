using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Random = UnityEngine.Random;


namespace OMONGoose
{
    public class AsteroidsTask : BaseTask
    {
        #region Fields

        [SerializeField] private GameObject _asteroidButtonPrefab;
        [SerializeField] private AnimationClip _clip;
        
        //Как лучше сделать: контролировать все астероиды из этого класса, но создавать 3 списка,
        // или создать новый MonoBehaviour класс для каждого астероида и контролировать их направление и аниматоры оттуда?
        // Сейчас все астероиды контролируются из одного класса, но я не уверен, что 3 списка - хорошая идея,
        // ведь при втором подходе можно было бы просто сделать список астероидов и вовремя вызывать у них тот или иной метод.
        
        private List<Button> _asteroids = new List<Button>();
        private List<Vector2> _directions = new List<Vector2>();
        private List<Animator> _animators = new List<Animator>();
        private Animator _animator;
        private Image _thisImage;
        private Canvas _canvas;
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
        private float _boundsOffset = 50.0f;

        #endregion


        #region Methods

        // Я не смог придумать, как вызывать Update из одного места в этом случае.
        // Ссылка на этот объект есть только в соответствующем TaskObject, ссылка на который есть только в TaskController
        // В этом же TaskController есть ещё куча ссылок на другие TaskObject, которые обновлять не надо.
        private void Update()
        {
            for (int i = 0; i < _asteroids.Count; i++)
            {
                if (_asteroids[i].transform.position.x >= _maxRight - _boundsOffset)
                    _asteroids[i].transform.Rotate(transform.forward, 90.0f);
                
                else if (_asteroids[i].transform.position.x <= _maxLeft + _boundsOffset)
                    _asteroids[i].transform.Rotate(transform.forward, -90.0f);
                
                else if (_asteroids[i].transform.position.y >= _maxUp - _boundsOffset)
                    _asteroids[i].transform.Rotate(transform.forward, 90.0f);

                else if (_asteroids[i].transform.position.y <= _maxDown + _boundsOffset)
                    _asteroids[i].transform.Rotate(transform.forward, 90.0f);

                _asteroids[i].transform.Translate(_directions[i]);
            }
        }

        public override void Initialize(RoomNames roomName)
        {
            base.Initialize(roomName);

            _thisImage = GetComponent<Image>();
            _maxProgress = 10.0f;

            //TODO: Передавать канвас при создании объекта
            _canvas = GetComponentInParent<Canvas>();
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
                    _asteroidButtonPrefab,
                    new Vector3(
                        Random.Range(_maxLeft + _startOffset, _maxRight - _startOffset),
                        Random.Range(_maxDown + _startOffset, _maxUp - _startOffset)),
                    Quaternion.identity,
                    _canvas.transform
                ).GetComponent<Button>();

                _asteroids.Add(asteroid);
                var i1 = i;
                _asteroids[i].onClick.AddListener(() => DestroyAsteroid(i1));
                var direction = new Vector2(
                    Random.Range(0, _asteroidSpeed),
                    Random.Range(0, _asteroidSpeed)).normalized * _asteroidSpeed;
                _directions.Add(direction * _canvasScaleFactor);
                var animator = _asteroids[i].GetComponent<Animator>();
                _animators.Add(animator);
            }
        }

        private void DestroyAsteroid(int i)
        {
            _animators[i].SetTrigger("Explosion");
            _asteroids[i].interactable = false;
            _audioSource.clip = _audioClips.AudioClips.AsteroidExplosion;
            _audioSource.Play();
            StartCoroutine(AsteroidExplosion(i));
            _progress++;
            if (_progress >= _maxProgress)
            {
                Completed();
            }
        }

        private IEnumerator AsteroidExplosion(int i)
        {
            yield return new WaitForSeconds(_clip.length);
            _asteroids[i].GetComponent<Image>().enabled = false;
            _asteroids[i].enabled = false;
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