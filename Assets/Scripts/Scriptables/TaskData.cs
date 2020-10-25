using UnityEngine;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "TaskData", menuName = "Data/Task Data")]
    public sealed class TaskData : ScriptableObject
    {
        public TaskStruct TaskStruct;
    }
}