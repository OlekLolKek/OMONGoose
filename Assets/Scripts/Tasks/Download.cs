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

        public override void Initialize(TaskController taskController)
        {
            base.Initialize(taskController);
            _maxProgress = 100.0f;
        }

        public override void SetName(RoomNames roomName)
        {
            base.SetName(roomName);
            _thisRoomText.text = $"{roomName}";
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
            IsDone = true;
            Completed();
            yield return new WaitForSeconds(0.75f);
            LeanTween.scale(_progressBar.gameObject, Vector3.zero, 0.1f);
        }

        #endregion
    }
}