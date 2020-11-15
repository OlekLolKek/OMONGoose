using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public class TaskbarView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;
        private int _totalTasks = 0;

        #endregion


        #region Methods

        public void Initialize(int totalTasks, TaskModel taskModel)
        {
            _slider.value = 0.0f;
            _totalTasks = totalTasks;
            _text.text = $"0 / {_totalTasks}";
            taskModel.OnTasksDoneChanged += TaskCompleted;
        }

        public void TaskCompleted(int tasksDone)
        {
            _slider.value = (float)tasksDone / (float)_totalTasks;
            _text.text = $"{tasksDone} / {_totalTasks}";
        }

        #endregion
    }
}