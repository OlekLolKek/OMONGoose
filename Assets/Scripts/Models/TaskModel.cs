using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskModel
    {
        public TaskStruct TaskStruct;

        public TaskModel(TaskStruct taskStruct)
        {
            TaskStruct = taskStruct;
        }
    }
}