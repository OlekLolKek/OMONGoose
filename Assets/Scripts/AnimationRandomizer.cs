using UnityEngine;
using System.Collections;


public class AnimationRandomizer : MonoBehaviour
{
    #region Fields

    private Animator _animator;
    private float _direction;
    private float _speed;

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
        StartCoroutine(nameof(ChangeParameters));
    }

    #endregion


    #region Methods

    private IEnumerator ChangeParameters()
    {
        for(; ; )
        {
            _direction = Random.Range(-1.0f, 1.0f);
            _speed = Random.Range(0.0f, 2.0f);
            _animator.SetFloat("Direction", _direction);
            _animator.SetFloat("Speed", _speed);
            yield return new WaitForSeconds(5);
        }
    }

    #endregion
}
