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
        
        /// <summary>
        /// Add box into pool dictionary
        /// </summary>
        private void AddIntoPool()
        {
            int boxIndex = 0;
            boxes.ForEach(box =>
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < box.size; i++)
                {
                    GameObject boxClone = Instantiate(box.prefab);
                    boxClone.SetActive(false);
                    boxClone.name = boxIndex.ToString();
                    objectPool.Enqueue(boxClone);
                }
                
                boxIndex++;
                boxDictionary.Add(box.classificationTag, objectPool);
            });
        }
        
        /// <summary>
        /// Spawn box from pool dictionary
        /// </summary>
        /// <param name="classificationTag">Random box number</param>
        /// <param name="position">Box position</param>
        /// <returns>Box fom pool dictionary</returns>
        public GameObject SpawnFromPool(int classificationTag, Vector2 position)
        {
            if (!boxDictionary.ContainsKey(classificationTag))
            {
                Debug.LogWarning($"Object with tag {classificationTag} doesn't exist");
                return null;
            }

            GameObject boxToSpawn = boxDictionary[classificationTag].Dequeue();
            boxToSpawn.SetActive(true);
            boxToSpawn.transform.position = position;
            
            boxDictionary[classificationTag].Enqueue(boxToSpawn);
            
            return boxToSpawn;
        }
    }
}
