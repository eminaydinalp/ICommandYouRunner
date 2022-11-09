using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Concretes.Utilities
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler Instance;
        
        [System.Serializable]
        public class Pool
        {
            public string type;
            public GameObject prefab;
            public int size;
        }
        
        public List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private GameObject _objectToSpawn;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                GameObject parent = new GameObject();
                parent.name = pool.type;
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab,parent.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                _poolDictionary.Add(pool.type, objectPool);
            }
        }

        public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(type))
            {
                Debug.LogWarning("Pool with type : " + type + " doesn't exist.");
                return null;
            }

            _objectToSpawn = _poolDictionary[type].Dequeue();
            _objectToSpawn.SetActive(true);
            _objectToSpawn.transform.position = position;
            _objectToSpawn.transform.rotation = rotation;

            _poolDictionary[type].Enqueue(_objectToSpawn);

            return _objectToSpawn;
        }

        public void DeActiveGameObjet(GameObject objectToDeActive)
        {
            objectToDeActive.SetActive(false);
        }
    
    }
}