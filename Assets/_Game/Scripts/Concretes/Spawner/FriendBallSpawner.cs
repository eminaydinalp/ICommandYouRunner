using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Concretes.Spawner
{
    public class FriendBallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnObject;
        [SerializeField] private Transform mainBall;
        [SerializeField] private int spawnCount;
        [SerializeField] private float spawnRadius;

        private void Start()
        {
            CreateEnemiesAroundPoint();
        }

        private void CreateEnemiesAroundPoint()
        {
 
            for (int i = 0; i < spawnCount; i++)
            {
 
                var radians = 2 * Mathf.PI / 360 * i;
 
                var vertical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);
 
                var spawnDir = new Vector3(horizontal, 0, vertical);
 
                var spawnPos = mainBall.position + spawnDir * Random.Range(0, spawnRadius);
 
                var enemy = Instantiate(spawnObject, spawnPos, Quaternion.identity) as GameObject;
                
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateEnemiesAroundPoint();
            }
        }
    }
}
