using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Concretes.Attack;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Spawner;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class FriendBallGroupController : CharacterBaseController
    {
        [SerializeField] private FriendBallSpawner _friendBallSpawner;
        [SerializeField] private FriendBallAttack _friendBallAttack;
        private void OnValidate()
        {
            if (_friendBallSpawner == null)
            {
                _friendBallSpawner = GetComponent<FriendBallSpawner>();
            }

            if (_friendBallAttack == null)
            {
                _friendBallAttack = GetComponent<FriendBallAttack>();
            }
        }

        private void OnEnable()
        {
            EventManager.OnTriggerLensIncrease += _friendBallSpawner.CreateBall;
            EventManager.OnFinishMelt += DefaultVerticalMove;
            EventManager.OnTriggerLensDecrease += _friendBallSpawner.DecreaseBall;
            EventManager.OnTriggerCollectable += _friendBallSpawner.FindSmallestBallScale;
            EventManager.OnTriggerFinishArea += () => verticalMoveSpeed = minVerticalMoveSpeed;
            EventManager.OnFinishAttackAnimation += () => verticalMoveSpeed = defaultVerticalMoveSpeed;

        }

        private void OnDisable()
        {
            EventManager.OnTriggerLensIncrease -= _friendBallSpawner.CreateBall;
            EventManager.OnFinishMelt -= DefaultVerticalMove;
            EventManager.OnTriggerLensDecrease -= _friendBallSpawner.DecreaseBall;
            EventManager.OnTriggerCollectable -= _friendBallSpawner.FindSmallestBallScale;
            EventManager.OnTriggerFinishArea -= () => verticalMoveSpeed = minVerticalMoveSpeed;
            EventManager.OnFinishAttackAnimation -= () => verticalMoveSpeed = defaultVerticalMoveSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemyBallGroupController = other.GetComponent<EnemyBallGroupController>();

            if (enemyBallGroupController != null)
            {
                //ToDo: Buraya baksak iyi olacak sanırım.
                EventManager.OnStartMelt?.Invoke();
                verticalMoveSpeed = minVerticalMoveSpeed;
                
                enemyBallGroupController.verticalMoveSpeed =minVerticalMoveSpeed;
                _friendBallAttack.selfBallSpawner = _friendBallSpawner;
                _friendBallAttack.enemyBallSpawner = enemyBallGroupController.enemyBallSpawner;
                
                enemyBallGroupController.enemyBallAttack.selfBallSpawner = enemyBallGroupController.enemyBallSpawner;
                enemyBallGroupController.enemyBallAttack.enemyBallSpawner = _friendBallSpawner;

                _friendBallAttack.isAttack = true;
                enemyBallGroupController.enemyBallAttack.isAttack = true;

            }
        }

        private void DefaultVerticalMove()
        {
            if(GameManager.Instance.isFinishAttackArea) return;

            verticalMoveSpeed = defaultVerticalMoveSpeed;
        }
    }
}
