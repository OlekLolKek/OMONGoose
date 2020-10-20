using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public class TaskbarView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        #endregion


        #region Methods

        public void Initialize(int totalTasks)
        {
            _slider.value = 0.0f;
            _text.text = $"0 / {totalTasks}";
        }

        public void TaskCompleted(int tasksDone, int totalTasks)
        {
            _slider.value = (float)tasksDone / (float)totalTasks;
            _text.text = $"{tasksDone} / {totalTasks}";
        }

        #endregion
    }
}