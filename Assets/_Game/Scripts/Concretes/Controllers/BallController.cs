using System;
using _Game.Scripts.Abstracts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class BallController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyBall"))
            {
                var otherBallSpawner = other.transform.parent.GetComponent<BallSpawner>();
                otherBallSpawner.activeBalls.Remove(other.gameObject);
                otherBallSpawner.SetNumberOfBalls();
                
                var selfBallSpawner = transform.parent.GetComponent<BallSpawner>();
                selfBallSpawner.activeBalls.Remove(gameObject);
                selfBallSpawner.SetNumberOfBalls();

                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
