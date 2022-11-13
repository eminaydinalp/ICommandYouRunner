using _Game.Scripts.Concretes.Controllers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Animations
{
    public class PlayerAnimation 
    {
        private Animator _animator;
        private PlayerController _playerController;
        public PlayerAnimation(PlayerController playerController)
        {
            _playerController = playerController;
            _animator = _playerController.GetComponentInChildren<Animator>();
        }

        public void FailAnimPlay()
        {
            _animator.SetBool("isFail", true);
        }
        
        public void WinAnimPlay()
        {
            _animator.SetBool("isWin", true);
        }

        public void AttackAnimPlay()
        {
            _animator.SetBool("isAttack", true);
        }

        public void SetMoveSpeedFast(float value)
        {
            _animator.SetFloat("moveSpeed", value);
        }
        
    }
}
