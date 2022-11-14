using System.Collections;
using _Game.Scripts.Abstracts.Managers;
using _Game.Scripts.Concretes.Utilities;
using UnityEngine;

namespace _Game.Scripts.Concretes.Managers
{
    public class EnemyBallSpawnManager : SpawnerManager
    {
        private const float SpawnYPosition = -0.4f;
        private bool spawnFinish;
        private void Start()
        {
            StartCoroutine(FirstSpawn());
        }

        private void OnEnable()
        {
            EventManager.OnTriggerFinishArea += () => spawnFinish = true;
        }

        private void OnDisable()
        {
            EventManager.OnTriggerFinishArea -= () => spawnFinish = true;
        }

        protected override void Spawn()
        {
            if(spawnFinish) return;
            ObjectPooler.Instance.SpawnFromPool(spawnObjectType, 
                new Vector3(transform.position.x, SpawnYPosition, transform.position.z), 
                Quaternion.identity);
        }

        IEnumerator FirstSpawn()
        {
            yield return new WaitForSeconds(0.1f);
            Spawn();
        }
    }
}
