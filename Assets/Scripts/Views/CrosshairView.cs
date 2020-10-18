using UnityEngine;


namespace OMONGoose
{
    public sealed class CrosshairView : MonoBehaviour
    {
        #region Fields

        private Vector3 _defaultScale = new Vector3(1.0f, 1.0f, 1.0f);
        //private Vector3 _largeScale = new Vector3(1.25f, 1.25f, 1.25f);
        private Vector3 _largeScale = new Vector3(5.0f, 5.0f, 5.0f);
        private float _scaleTime = 0.1f;

        #endregion

        #region Methods

        public void TaskLocated()
        {
            LeanTween.scale(gameObject, _largeScale, _scaleTime);
        }

        public void TaskUnlocated()
        {
            LeanTween.scale(gameObject, _defaultScale, _scaleTime);
        }

        #endregion
    }
}