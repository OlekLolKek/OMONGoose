using UnityEngine;


namespace OMONGoose
{
    public class TaskModel : MonoBehaviour
    {
        public TaskStruct TaskStruct;

        public TaskModel(TaskStruct taskStruct)
        {
            TaskStruct = taskStruct;
        }
    }
}