using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Attack;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Spawner;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class FriendBallGroupController : VerticalMovementBase
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
            EventManager.OnTriggerLens += _friendBallSpawner.MakeStickMan;
            EventManager.OnFinishMelt += DefaultVerticalMove;
        }

        private void OnDisable()
        {
            EventManager.OnTriggerLens -= _friendBallSpawner.MakeStickMan;
            EventManager.OnFinishMelt -= DefaultVerticalMove;
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

                //StartCoroutine(_friendBallAttack.UpdateTheEnemyAndPlayerStickMansNumbers());
            }
        }

        private void DefaultVerticalMove()
        {
            verticalMoveSpeed = defaultVerticalMoveSpeed;
        }
    }
}
