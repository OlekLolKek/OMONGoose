using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public sealed class Download : BaseTask
    {
        #region Fields

        [SerializeField] private Button _downloadButton;
        [SerializeField] private Image _progressBar;
        [SerializeField] private Image _arrow;
        [SerializeField] private Text _thisRoomText;
        [SerializeField] private Text _buttonText;

        private float _downloadSpeed = 15.0f;

        #endregion


        #region Methods

        public override void Initialize(RoomNames roomName)
        {
            base.Initialize(roomName);
            _maxProgress = 100.0f;
            var random = new System.Random();
            int arrowRotation = random.Next(2);
            if (arrowRotation == 1)
            {
                _arrow.transform.Rotate(transform.forward, 180.0f);
                _buttonText.text = "Upload";
                _thisRoomText.text = "HQ";
            }
            else
            {
                _thisRoomText.text = $"{roomName}";
            }
        }

        public void OnDownloadButtonPressed()
        {
            StartCoroutine(StartDownload());
        }

        private IEnumerator StartDownload()
        {
            _downloadButton.interactable = false;
            LeanTween.scale(_downloadButton.gameObject, _normalSize, _tweenTime);
            Destroy(_downloadButton.gameObject, _tweenTime);

            while (_progress < _maxProgress)
            {
                _progress += Time.deltaTime * _downloadSpeed;
                _progressBar.fillAmount = _progress / _maxProgress;
                yield return 0;
            }
            Completed();
            yield return new WaitForSeconds(0.75f);
            LeanTween.scale(_progressBar.gameObject, Vector3.zero, 0.1f);
        }

        #endregion
    }
}