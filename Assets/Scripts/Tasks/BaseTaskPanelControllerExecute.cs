using UnityEngine;

namespace OMONGoose
{
    public abstract class BaseTaskPanelControllerExecute : BaseTaskPanelController, IExecutable
    {   
        protected BaseTaskPanelControllerExecute(Canvas canvas, GameObject taskPanelPrefab) : base(canvas, taskPanelPrefab)
        {
        }
        
        public abstract void Execute(float deltaTime);
    }
}