using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerGUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Material _floorMaterial;
        [SerializeField] private Color _floorColor;

        private string _tasksText;
        private float _boxOffsetX = 5;
        private float _boxOffsetY = 5;
        private float _boxSizeX = 100;
        private float _boxSizeY = 25;

        private float _sliderOffsetX = 5;
        private float _sliderOffsetY = 35;
        private float _sliderSizeX = 100;
        private float _sliderSizeY = 25;
        private float _sliderStep = 25;
        private int _tasks = 10;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _tasksText = $"Tasks left: {_tasks}";
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(_boxOffsetX, _boxOffsetY, _boxSizeX, _boxSizeY), _tasksText);

            _floorColor = RGBASlider(new Rect(_sliderOffsetX, _sliderOffsetY, _sliderSizeX, _sliderSizeY), _floorColor);
            _floorMaterial.color = _floorColor;
        }

        #endregion


        #region Methods

        private float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, float sliderMinValue, string labelText)
        {
            Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

            GUI.Label(labelRect, labelText);

            Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
            sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue);
            return sliderValue;
        }

        private Color RGBASlider(Rect screenRect, Color rgba)
        {
            rgba.r = LabelSlider(screenRect, rgba.r, 1.0f, 0.0f, "Red");

            screenRect.y += _sliderStep;
            rgba.g = LabelSlider(screenRect, rgba.g, 1.0f, 0.0f, "Green");

            screenRect.y += _sliderStep;
            rgba.b = LabelSlider(screenRect, rgba.b, 1.0f, 0.0f, "Blue");

            screenRect.y += _sliderStep;
            rgba.a = LabelSlider(screenRect, rgba.a, 1.0f, 0.0f, "Alpha");

            return rgba;
        }

        #endregion
    }

}