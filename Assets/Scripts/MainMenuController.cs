using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public sealed class MainMenuController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _camera;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _rotateSpeed;

    #endregion


    #region UnityMethods

    private void Update()
    {
        _camera.transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    #endregion


    #region Methods

    public void OnSingleplayerButtonPressed()
    {
        StartCoroutine(Singleplayer());
    }

    private IEnumerator Singleplayer()
    {
        Color newColor = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, _fadeImage.color.a);
        while (_fadeImage.color.a < 1)
        {
            newColor.a += Time.deltaTime;
            _fadeImage.color = newColor;

            yield return 0;
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    #endregion
}
