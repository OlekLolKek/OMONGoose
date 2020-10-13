using UnityEngine;


public class MainMenuController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _camera;
    [SerializeField] private float _rotateSpeed;

    #endregion


    #region UnityMethods

    private void Update()
    {
        _camera.transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    #endregion
}
