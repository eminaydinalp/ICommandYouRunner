using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Spawner;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class EnemyBallGroupController : VerticalMovementBase
    {
        [SerializeField] private EnemyBallSpawner _enemyBallSpawner;
        
        private void OnValidate()
        {
            if (_enemyBallSpawner == null)
            {
                _enemyBallSpawner = GetComponent<EnemyBallSpawner>();
            }
        }

        private void Start()
        {
            StartCoroutine(_enemyBallSpawner.CreateEnemyBalls());
        }
    }
}
