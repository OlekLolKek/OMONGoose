using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public sealed class DownloadTaskView : BaseTaskView
    {
        #region Fields

        public Button DownloadButton;
        public Image ProgressBar;
        [SerializeField] private Image _arrow;
        [SerializeField] private Text _thisRoomText;
        [SerializeField] private Text _buttonText;

        #endregion


        #region Methods

        public void Download(RoomNames roomName)
        {
            _thisRoomText.text = $"{roomName}";
        }

        public void Upload()
        {
            _arrow.transform.Rotate(transform.forward, 180.0f);
            _buttonText.text = "Upload";
            _thisRoomText.text = "HQ";
        }

        #endregion
    }
}