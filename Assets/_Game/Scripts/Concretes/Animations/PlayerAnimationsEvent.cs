using _Game.Scripts.Concrates.Utilities;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Animations
{
    public class PlayerAnimationsEvent : MonoBehaviour
    {
        public void AttackAnimationEvent()
        {
            EventManager.OnFinishAttackAnimation?.Invoke();
            SoundManager.Instance.PlaySound(Consts.BallGroupAttackSoundIndex);
        }
    }
}
