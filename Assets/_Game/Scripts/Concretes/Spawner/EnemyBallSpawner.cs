using System.Collections;
using _Game.Scripts.Abstracts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Concretes.Spawner
{
    public class EnemyBallSpawner : BallSpawner
    {
        [SerializeField] private int minBallCount;
        [SerializeField] private int maxBallCount;
        public int ballCount;
        

        public IEnumerator CreateEnemyBalls()
        {
            ballCount = Random.Range(minBallCount, maxBallCount);
            
            yield return new WaitForSeconds(0.01f);
            
            CreateBall(ballCount);
        }
    }
}