using System.Collections.Generic;
using _Game.Scripts.Concretes.Utilities;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Abstracts.Spawner
{
    public abstract class BallSpawner : MonoBehaviour 
    {
        public string spawnObjectType;
        
        public int numberOfBalls;
        
        [Range(0f,1f)] [SerializeField] private float distanceFactor, radius;

        public List<GameObject> activeBalls = new();

        private const float SpawnTime = 1.5f;
        private const float SpawnObjectYPos = 0;
        
        protected virtual void Start()
        {
            numberOfBalls = activeBalls.Count;
        }

        public void CreateBall(int number)
        {
            number += numberOfBalls;
            
            for (var i = numberOfBalls; i < number; i++)
            {
                var ball = ObjectPooler.Instance.SpawnFromPool(spawnObjectType, transform.position, Quaternion.identity);
                ball.transform.SetParent(transform);
                activeBalls.Add(ball);
            }

            SetNumberOfBalls();
            FormatBallGroup();
        }
        
        public void FormatBallGroup()
        {
            for (var i = 0; i < activeBalls.Count; i++)
            {
                var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
                var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
            
                var newPos = new Vector3(x,SpawnObjectYPos,z);

                activeBalls[i].GameObject().transform.DOLocalMove(newPos, SpawnTime).SetEase(Ease.OutBack);
            }
        }

        public void SetNumberOfBalls()
        {
            numberOfBalls = activeBalls.Count;
        }
    }
}