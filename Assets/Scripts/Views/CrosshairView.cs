using UnityEngine;


namespace OMONGoose
{
    public sealed class CrosshairView : MonoBehaviour, IInitializable
    {
        #region Fields

        private CrosshairEvent _crosshairEvent;
        private readonly Vector3 _defaultScale = new Vector3(1.0f, 1.0f, 1.0f);
        private readonly Vector3 _largeScale = new Vector3(4.0f, 4.0f, 4.0f);
        private float _scaleTime = 0.1f;

        #endregion

        #region Methods

        public void Initialization()
        {
            
        }
        
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