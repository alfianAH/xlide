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
                    SetBox(i, j);
                }
            }
        }
        
        /// <summary>
        /// Set Box in index i, j
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void SetBox(int i, int j)
        {
            Vector2 pos = new Vector2(startPos.x + i*offset.x, startPos.y + j*offset.y);
                    
            int randomBox = Random.Range(0, ObjectPooler.Instance.boxes.Count);
                    
            GameObject box = ObjectPooler.Instance.SpawnFromPool(randomBox, pos);
                    
            boxes[i, j] = box;
        }
        
        /// <summary>
        /// Get the bottom box
        /// </summary>
        /// <returns>boxes[0,0]</returns>
        public GameObject GetBottomBox()
        {
            return boxes[0, 0];
        }
        
        /// <summary>
        /// Destroy the bottom box
        /// </summary>
        public void DestroyBox()
        {
            boxes[0, 0].SetActive(false);
            boxes[0, 0] = null;

            DecreaseRow();
        }
        
        /// <summary>
        /// Decrease row in boxes when destroying
        /// </summary>
        private void DecreaseRow()
        {
            int nullCount = 0;

            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    if (boxes[i, j] == null) nullCount++;
                    else if (nullCount > 0)
                    {
                        boxes[i, j - 1] = boxes[i, j];
                        boxes[i, j] = null;
                    }
                }

                nullCount = 0;
            }
            
            RefillBox();
        }
        
        /// <summary>
        /// Refill box 
        /// </summary>
        private void RefillBox()
        {
            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    if (boxes[i, j] == null)
                    {
                        SetBox(i, j);
                    }
                }
            }
        }
    }
}
