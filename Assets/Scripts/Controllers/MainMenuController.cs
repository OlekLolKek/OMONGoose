using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;


namespace OMONGoose
{
    public sealed class MainMenuController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PostProcessVolume _postProcessing;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Button _highButton;
        [SerializeField] private Button _lowButton;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _camera;
        [SerializeField] private Image _fadeImage;
        [SerializeField] private float _rotateSpeed;

        private string _musicVolume = "Music";
        private string _soundVolume = "Sound";
        private float _maxMusicVolume = -30.0f;
        private float _maxSoundVolume = 0.0f;
        private float _minVolume = -80.0f;

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

        public void OnSettingsButtonPressed()
        {
            SwitchState(MainMenuStates.SettingsMenu);
        }

        public void OnExitButtonPressed()
        {
            Application.Quit();
        }


        public void OnHighButtonPressed()
        {
            QualitySettings.SetQualityLevel(1);
            _postProcessing.enabled = true;
        }

        public void OnLowButtonPressed()
        {
            QualitySettings.SetQualityLevel(0);
            _postProcessing.enabled = false;
        }

        public void OnSettingsBackButtonPressed()
        {
            SwitchState(MainMenuStates.MainMenu);
        }

        public void OnMusicToggleChecked(bool isChecked)
        {
            if (isChecked)
            {
                _audioMixer.SetFloat(_musicVolume, _maxMusicVolume);
            }
            else
            {
                _audioMixer.SetFloat(_musicVolume, _minVolume);
            }
        }

        public void OnSoundToggleChecked(bool isChecked)
        {
            if (isChecked)
            {
                _audioMixer.SetFloat(_soundVolume, _maxSoundVolume);
            }
            else
            {
                _audioMixer.SetFloat(_soundVolume, _minVolume);
            }
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

        private void SwitchState(MainMenuStates state)
        {
            switch (state)
            {
                case MainMenuStates.MainMenu:
                    _mainMenu.SetActive(true);
                    _settingsMenu.SetActive(false);
                    break;
                case MainMenuStates.SettingsMenu:
                    _mainMenu.SetActive(false);
                    _settingsMenu.SetActive(true);
                    break;
            }
        }

        #endregion
    }
}