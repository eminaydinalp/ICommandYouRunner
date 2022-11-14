using System;
using _Game.Scripts.Abstracts.Spawner;
using _Game.Scripts.Concrates.Utilities;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts.Concretes.Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private GameObject ballParticle;
        public float scale;
        public float increaseAmount;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyBall"))
            {
                var otherBallSpawner = other.transform.parent.GetComponent<BallSpawner>();
                otherBallSpawner.activeBalls.Remove(other.GetComponent<NavMeshAgent>());
                otherBallSpawner.SetNumberOfBalls();
                
                var selfBallSpawner = transform.parent.GetComponent<BallSpawner>();
                selfBallSpawner.activeBalls.Remove(gameObject.GetComponent<NavMeshAgent>());
                selfBallSpawner.SetNumberOfBalls();

                Instantiate(ballParticle, transform.position, Quaternion.identity);
                
                SoundManager.Instance.PlaySound(Consts.TriggerBallSoundIndex);
                
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        

        public void IncreaseScale()
        {
            scale += increaseAmount;
            transform.localScale += Vector3.one * scale;
            transform.position += Vector3.up * scale * 0.5f;
        }
    }
}
