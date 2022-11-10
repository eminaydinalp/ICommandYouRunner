using _Game.Scripts.Concretes.Utilities;
using UnityEngine;

namespace _Game.Scripts.Abstracts.Managers
{
    public abstract class SpawnerManager : MonoBehaviour
    {
        [SerializeField] protected string spawnObjectType;
        
        [Range(0.5f, 3)] [SerializeField] private float minSpawnTime;
        [Range(2, 10)] [SerializeField] private float maxSpawnTime;

        [SerializeField] private float spawnTime;

        private float _currentTime;
        
        private void OnEnable()
        {
            ChangeSpawnTime();
        }
        
        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= spawnTime)
            {
                _currentTime = 0;
                
                Spawn();
            }
        }
        
        protected virtual void Spawn()
        {
            ChangeSpawnTime();
        }
        
        private void ChangeSpawnTime()
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}