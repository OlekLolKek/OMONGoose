namespace OMONGoose
{
    public abstract class BaseTaskViewExecutable : BaseTaskView, IExecutable
    {
        public abstract void Execute(float deltaTime);
    }
}