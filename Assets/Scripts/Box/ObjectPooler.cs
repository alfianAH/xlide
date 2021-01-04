using System;
using System.Collections.Generic;
using UnityEngine;

namespace Box
{
    public class ObjectPooler : MonoBehaviour
    {
        public List<Box> boxes;

        public Dictionary<int, Queue<GameObject>> boxDictionary;
        public static ObjectPooler Instance;

        private void Awake()
        {
            Instance = this;
            boxDictionary = new Dictionary<int, Queue<GameObject>>();
            AddIntoPool();
        }

        private void AddIntoPool()
        {
            boxes.ForEach(box =>
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < box.size; i++)
                {
                    GameObject boxClone = Instantiate(box.prefab);
                    boxClone.SetActive(false);
                    objectPool.Enqueue(boxClone);
                }
                
                boxDictionary.Add(box.tag, objectPool);
            });
        }

        public GameObject SpawnFromPool(int tag)
        {
            if (!boxDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Object with tag {tag} doesn't exist");
                return null;
            }

            GameObject boxToSpawn = boxDictionary[tag].Dequeue();
            boxToSpawn.SetActive(true);
            
            boxDictionary[tag].Enqueue(boxToSpawn);
            
            return boxToSpawn;
        }
    }
}
