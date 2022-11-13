using System;
using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Concretes.Attack;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Spawner;

namespace _Game.Scripts.Concretes.Controllers
{
    public class EnemyBallGroupController : CharacterBaseController
    {
        public EnemyBallSpawner enemyBallSpawner;
        public EnemyBallAttack enemyBallAttack;
        
        private void OnValidate()
        {
            if (enemyBallSpawner == null)
            {
                enemyBallSpawner = GetComponent<EnemyBallSpawner>();
            }
        }

        private void Start()
        {
            StartCoroutine(enemyBallSpawner.CreateEnemyBalls());
        }

        private void OnEnable()
        {
            EventManager.OnFinishAttackAnimation += SetDefaultVerticalMove;
        }

        private void OnDisable()
        {
            EventManager.OnFinishAttackAnimation += SetDefaultVerticalMove;
        }

        private void SetDefaultVerticalMove()
        {
            verticalMoveSpeed = defaultVerticalMoveSpeed;
        }
    }
}
