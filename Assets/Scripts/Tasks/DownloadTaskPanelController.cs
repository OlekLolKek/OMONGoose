using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using UniRx;
using Object = UnityEngine.Object;


namespace OMONGoose
{
    public class DownloadTaskPanelController : BaseTaskPanelController
    {
        private DownloadTaskView _downloadTaskViewPanel;
        private float _downloadSpeed = 15.0f;
        private float _completedDelay = 0.75f;
        private IDisposable _coroutine;
        private readonly RoomNames _roomName;

        public DownloadTaskPanelController(RoomNames roomName, Canvas canvas, GameObject taskPanelPrefab) 
            : base(canvas, taskPanelPrefab)
        {
            _maxProgress = 100.0f;
            _roomName = roomName;
        }

        protected override void Activate()
        {
            base.Activate();
            _downloadTaskViewPanel = (DownloadTaskView) _taskViewPanel;
            RandomTypeSelection();
            _downloadTaskViewPanel.DownloadButton.onClick.AddListener(OnDownloadButtonPressed);
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            _coroutine?.Dispose();
            _downloadTaskViewPanel.DownloadButton.onClick.RemoveAllListeners();
        }

        private void RandomTypeSelection()
        {
            var random = new System.Random();
            int arrowRotation = random.Next(2);
            if (arrowRotation == 1)
            {
                _downloadTaskViewPanel.Upload();
            }
            else
            {
                _downloadTaskViewPanel.Download(_roomName);
            }
        }

        private void OnDownloadButtonPressed()
        {
            _coroutine = Observable.FromCoroutine(StartDownload).Subscribe();
        }

        private IEnumerator StartDownload()
        {
            var downloadButton = _downloadTaskViewPanel.DownloadButton;
            var progressBar = _downloadTaskViewPanel.ProgressBar;
            downloadButton.interactable = false;
            downloadButton.transform.DOScale(Vector3.zero, _tweenTime);
            Object.Destroy(downloadButton.gameObject, _tweenTime);

            while (_progress < _maxProgress)
            {
                _progress += Time.deltaTime * _downloadSpeed;
                progressBar.fillAmount = _progress / _maxProgress;
                yield return 0;
            }
            _downloadTaskViewPanel.Completed();
            progressBar.DOColor(Color.green, _tweenTime);
            yield return new WaitForSeconds(_completedDelay);
            progressBar.transform.DOScale(Vector3.zero, _tweenTime);
        }
    }
}