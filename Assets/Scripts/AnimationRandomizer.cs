using UnityEngine;
using System.Collections;


public class AnimationRandomizer : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform _rightHandObject = null;
    [SerializeField] private Transform _leftHandObject = null;
    [SerializeField] private Transform _lookObject = null;
    [SerializeField] private bool _ikActive = false;

    private Animator _animator;
    private float _direction;
    private float _speed;
    private bool _seesPlayer = false;
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
        var rayStart = new Vector3(transform.position.x, 4.0f, transform.position.z);

        if (Time.frameCount % 300 == 0)
        {
            StartCoroutine(nameof(ChangeParameters));
        }

        if (Physics.Raycast(rayStart, _lookObject.position - rayStart, out var hit, 15.0f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                _seesPlayer = true;
            }
            else
            {
                _seesPlayer = false;
            }
        }

        Debug.DrawRay(rayStart, _lookObject.position - rayStart, Color.red);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_ikActive)
        {
            if (_seesPlayer)
            {
                _animator.SetLookAtWeight(1);
                _animator.SetLookAtPosition(_lookObject.position);
            }
            else
            {
                _animator.SetLookAtWeight(0);
            }

            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandObject.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandObject.rotation);


            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandObject.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandObject.rotation);
        }
        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
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
