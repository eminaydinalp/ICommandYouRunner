using UnityEngine;

namespace _Game.Scripts.Abstracts.Managers
{
    public abstract class SpawnerManager : MonoBehaviour
    {
        [SerializeField] protected string spawnObjectType;
        
        [SerializeField] private float spawnTime;

        private float _currentTime;

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= spawnTime)
            {
                _currentTime = 0;
                
                Spawn();
            }
        }
        protected abstract void Spawn();


    }
}