using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Attack;
using _Game.Scripts.Concretes.Spawner;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class EnemyBallGroupController : VerticalMovementBase
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
    }
}
