using UnityEngine;


namespace OMONGoose
{
    public sealed class UILinks
    {
        #region Fields

        CrosshairView _crosshairView;

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

        #endregion
    }
}