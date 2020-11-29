using UnityEngine;

namespace OMONGoose
{
    public interface IPlayerFactory
    {
        void CreatePlayer();
        Transform GetTransform();
        CharacterController GetCharacterController();
        Camera GetCamera();
        Animator GetAnimator();
    }
}