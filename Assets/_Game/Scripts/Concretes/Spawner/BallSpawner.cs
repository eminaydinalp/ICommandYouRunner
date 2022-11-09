using System;
using System.Collections.Generic;
using _Game.Scripts.Concretes.Utilities;
using DG.Tweening;
using UnityEngine;


namespace _Game.Scripts.Concretes.Spawner
{
    public class BallSpawner : MonoBehaviour
    {
        public static BallSpawner Instance;
        
        public int numberOfBalls;
        
        [Range(0f,1f)] [SerializeField] private float distanceFactor, radius;

        private readonly List<GameObject> _activeBalls = new();

        private const float SpawnTime = 0.5f;
        private const float SpawnObjectYPos = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            numberOfBalls = _activeBalls.Count;
        }

        public void MakeStickMan(int number)
        {
            for (var i = numberOfBalls; i < number; i++)
            {
                GameObject ball = ObjectPooler.Instance.SpawnFromPool("FriendBall", transform.position, Quaternion.identity);
                ball.transform.SetParent(transform);
                _activeBalls.Add(ball);
            }

            numberOfBalls = _activeBalls.Count;
            FormatStickMan();
        }
        
        private void FormatStickMan()
        {
            for (var i = 0; i < _activeBalls.Count; i++)
            {
                var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
                var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
            
                var newPos = new Vector3(x,SpawnObjectYPos,z);

               _activeBalls[i].transform.DOLocalMove(newPos, SpawnTime).SetEase(Ease.OutBack);
            }
        }
        
    }
}
