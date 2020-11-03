namespace OMONGoose
{
    public interface IExecutable : IControllable
    { 
        void Execute(float deltaTime);
    }
}