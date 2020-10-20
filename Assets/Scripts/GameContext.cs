using UnityEngine;


namespace OMONGoose
{
    public sealed class GameContext
    {
        #region Fields

        private CrosshairView _crosshairView;
        private Canvas _canvas;

        #endregion


        #region Properties

        public CrosshairView CrosshairView
        {
            get
            {
                if (!_crosshairView)
                {
                    _crosshairView = Object.FindObjectOfType<CrosshairView>();
                }
                return _crosshairView;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (!_canvas)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        #endregion
    }
}