using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Concretes.Animations;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Movement;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class PlayerController : CharacterBaseController
    {
        private HorizontalMovement _horizontalMovement;

        private PlayerAnimation _playerAnimation;
        
        [Header("Horizontal Movement Information \n")] 
        [SerializeField] private Transform localMoverTarget;
        [SerializeField] private Transform localMover;

        [SerializeField] private float xPositionClamp;
        [SerializeField] private float horizontalMoveSpeed;
        [SerializeField] private float horizontalLerpSpeed;
        
        [Header("Run Animation Information \n")] 

        public float runAnimSpeedFast;
        public float runAnimSpeedSlow;

        private BoxCollider _collider;

        protected override void Awake()
        {
            base.Awake();
            _playerAnimation = new PlayerAnimation(this);
            _horizontalMovement =
                new HorizontalMovement(localMover, localMoverTarget, xPositionClamp, horizontalMoveSpeed, horizontalLerpSpeed);
        }

        private void OnEnable()
        {
            EventManager.OnStartMelt += DecreaseVerticalMove;
            EventManager.OnFinishMelt += DefaultVerticalMove;
            LeanTouch.OnFingerUpdate +=_horizontalMovement.SwerveLean;
            EventManager.OnFail += _playerAnimation.FailAnimPlay;
            EventManager.OnTriggerFinishArea += StopMove;
            EventManager.OnTriggerFinishArea += _playerAnimation.AttackAnimPlay;
            EventManager.OnWin += _playerAnimation.WinAnimPlay;
        }

        private void OnDisable()
        {
            EventManager.OnStartMelt -= DecreaseVerticalMove;
            EventManager.OnFinishMelt -= DefaultVerticalMove;
            LeanTouch.OnFingerUpdate -=_horizontalMovement.SwerveLean;
            EventManager.OnFail -= _playerAnimation.FailAnimPlay;
            EventManager.OnTriggerFinishArea -= StopMove;
            EventManager.OnTriggerFinishArea -= _playerAnimation.AttackAnimPlay;
            EventManager.OnWin -= _playerAnimation.WinAnimPlay;
        }
        
        private void Update()
        {
            _horizontalMovement.FollowLocalMoverTarget();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (GameManager.Instance.isFinish) return;
            
            var affectable = other.GetComponent<IAffectable>();

            affectable?.DoProcess();
        }

        private void DecreaseVerticalMove()
        {
            if(GameManager.Instance.isFinishAttackArea) return;

            verticalMoveSpeed = minVerticalMoveSpeed;
            
            _playerAnimation.SetMoveSpeedFast(runAnimSpeedSlow);
        }

        private void StopMove()
        {
            verticalMoveSpeed = 0;
        }
        
        private void DefaultVerticalMove()
        {
            if(GameManager.Instance.isFinishAttackArea) return;
            verticalMoveSpeed = defaultVerticalMoveSpeed;
            _playerAnimation.SetMoveSpeedFast(runAnimSpeedFast);
        }
        
    }
}
