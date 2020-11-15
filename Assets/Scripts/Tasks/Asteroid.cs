using System;
using OMONGoose;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;


public class Asteroid : MonoBehaviour, IExecutable
{
    #region Fields

    public event Action<int> OnAsteroidDestroyed = delegate { };

    [SerializeField] private AnimationClip _clip;

    private AudioSource _audioSource;
    private Animator _animator;
    private Vector2 _direction;
    private Button _button;
    private Image _image;
    private float _maxRight;
    private float _maxLeft;
    private float _maxUp;
    private float _maxDown;
    private float _boundsOffset = 50.0f;
    private float _speed = 2.0f;
    private int _index;

    private readonly int _explosion = Animator.StringToHash("Explosion");

    #endregion

    #region Methods

    public void Initialization(int index, float maxRight, float maxLeft, float maxUp, float maxDown)
    {
        _index = index;
        _maxRight = maxRight;
        _maxLeft = maxLeft;
        _maxUp = maxUp;
        _maxDown = maxDown;
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();

        _button.onClick.AddListener(DestroyAsteroid);

        _direction = new Vector2(
            Random.Range(0, _speed),
            Random.Range(0, _speed)).normalized * _speed;
    }

    public void Execute(float deltaTime)
    {
        if (transform.position.x >= _maxRight - _boundsOffset)
            transform.Rotate(transform.forward, 90.0f);

        else if (transform.position.x <= _maxLeft + _boundsOffset)
            transform.Rotate(transform.forward, -90.0f);

        else if (transform.position.y >= _maxUp - _boundsOffset)
            transform.Rotate(transform.forward, 90.0f);

        else if (transform.position.y <= _maxDown + _boundsOffset)
            transform.Rotate(transform.forward, 90.0f);

        transform.Translate(_direction);
    }

    private void DestroyAsteroid()
    {
        _animator.SetTrigger(_explosion);
        _button.interactable = false;
        _audioSource.Play();
        StartCoroutine(AsteroidExplosion());
        OnAsteroidDestroyed.Invoke(_index);
    }

    private IEnumerator AsteroidExplosion()
    {
        yield return new WaitForSeconds(_clip.length);
        _image.enabled = false;
        _button.enabled = false;
    }

    #endregion
}