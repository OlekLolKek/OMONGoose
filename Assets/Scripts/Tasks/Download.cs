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
        [SerializeField] private Text _thisRoomText;

        private float _downloadSpeed = 15.0f;

        #endregion


        #region Methods

        protected override void Awake()
        {
            base.Awake();
            _thisRoomText.text = "";
            _maxProgress = 100.0f;
        }

        public override void SetName(RoomNames roomName)
        {
            base.SetName(roomName);
            switch (RoomName)
            {
                case RoomNames.Weapons:
                    _thisRoomText.text = "Weapons";
                    break;
                case RoomNames.Cafeteria:
                    _thisRoomText.text = "Cafeteria";
                    break;
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
            yield return new WaitForSeconds(0.75f);
            _progressBar.gameObject.SetActive(false);
            IsDone = true;
        }

        #endregion
    }
}