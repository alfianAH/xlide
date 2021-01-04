using UnityEngine;

namespace Box
{
    public class Grid : MonoBehaviour
    {
        public int gridSizeX, 
            gridSizeY;
        public GameObject boxPrefab;
        
        private Vector3 startPos, offset;
        private GameObject[,] boxes;
        
        // Start is called before the first frame update
        private void Start()
        {
            CreateGrid();
        }
        
        /// <summary>
        /// Create grid when game starts
        /// </summary>
        private void CreateGrid()
        {
            boxes = new GameObject[gridSizeX, gridSizeY];
            
            // Set offset from prefab's size
            offset = boxPrefab.GetComponent<SpriteRenderer>().bounds.size;
            
            // Set start position
            startPos = transform.position;
            
            // Make boxes
            MakeBoxes();
        }
        
        /// <summary>
        /// Make boxes in grid
        /// </summary>
        private void MakeBoxes()
        {
            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    Vector2 pos = new Vector2(startPos.x + i*offset.x, startPos.y + j*offset.y);
                    
                    int randomBox = Random.Range(0, ObjectPooler.Instance.boxes.Count);
                    
                    GameObject box = ObjectPooler.Instance.SpawnFromPool(randomBox, pos);
                    
                    boxes[i, j] = box;
                }
            }
        }
    }
}
