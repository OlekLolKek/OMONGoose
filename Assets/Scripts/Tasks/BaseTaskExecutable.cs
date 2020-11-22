namespace OMONGoose
{
    public abstract class BaseTaskExecutable : BaseTask, IExecutable
    {
        public abstract void Execute(float deltaTime);
    }
}