using UnityEngine;
using System.Collections;


public class AnimationRandomizer : MonoBehaviour
{
    #region Fields

    private Animator _animator;
    private float _direction;
    private float _speed;
    private int _counter;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _direction = _animator.GetFloat("Direction");
        _speed = _animator.GetFloat("Speed");
    }

    private void Update()
    {
        if (Time.frameCount % 300 == 0)
        {
            StartCoroutine(nameof(ChangeParameters));
        }
    }

    #endregion


    #region Methods

    private IEnumerator ChangeParameters()
    {
        var newDir = Random.Range(-1.0f, 1.0f);
        var newSpeed = Random.Range(0.0f, 2.0f);

        while (!Mathf.Approximately(_direction, newDir) || !Mathf.Approximately(_speed, newSpeed))
        {
            _direction = Mathf.Lerp(_direction, newDir, 0.1f);
            _speed = Mathf.Lerp(_speed, newSpeed, 0.1f);
            _animator.SetFloat("Direction", _direction);
            _animator.SetFloat("Speed", _speed);
            yield return 0;
        }
    }

    #endregion
}
