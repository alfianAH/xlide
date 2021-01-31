using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Box
{
    public class Grid : MonoBehaviour
    {
        public int gridSizeX, 
            gridSizeY;
        public GameObject boxPrefab;
        
        [SerializeField] private LevelManager levelManager;
        
        private Vector3 startPos, offset;
        private GameObject[,] boxes;

        #region MONOBEHAVIOUR_METHODS
        
        // Start is called before the first frame update
        private void Start()
        {
            CreateGrid();
        }
        
        #endregion
        
        #region PUBLIC_METHODS
        
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
        
        #endregion
        
        #region PRIVATE_METHODS

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
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        private void SetBox(int gridX, int gridY)
        {
            Vector2 pos;
            if (boxes[gridX, gridSizeY - 2] != null)
            {
                pos = new Vector2(startPos.x + gridX*offset.x, 
                    offset.y + boxes[gridX, gridSizeY-2].transform.position.y);
            }
            else
            {
                pos = new Vector2(startPos.x + gridX*offset.x, 
                    startPos.y + gridY*offset.y);
            }

            int randomBox = SetRandomNumber(gridX, gridY);
            GameObject box = ObjectPooler.Instance.SpawnFromPool(randomBox, pos);
            boxes[gridX, gridY] = box;
        }

        /// <summary>
        /// Set random number for boxes
        /// </summary>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <returns></returns>
        private int SetRandomNumber(int gridX, int gridY)
        {
            int randomBox = Random.Range(0, ObjectPooler.Instance.boxes.Count);
            
            // Check box other than boxes[0,0]
            if (gridY != 0)
            {
                int previousValue = Int32.Parse(boxes[gridX, gridY - 1].name);
                
                // Check similarity in boxes
                if (levelManager.IsSimilarLimit(randomBox, previousValue))
                {
                    // Loop until random box != targetValue
                    while (randomBox == previousValue)
                    {
                        randomBox = Random.Range(0, ObjectPooler.Instance.boxes.Count);
                    }
                }
            }

            return randomBox;
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

        #endregion
        
    }
}
