using System;
using UnityEngine;
using Grid = Box.Grid;

namespace Inputs
{
    public class LeftRightButtonHandler : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        
        /// <summary>
        /// Check each button
        /// </summary>
        /// <param name="correctBox"></param>
        public void CheckButton(int correctBox)
        {
            GameObject bottomBox = grid.GetBottomBox();
            int bottomBoxName = Convert.ToInt32(bottomBox.name);
            
            if (correctBox == bottomBoxName)
            {
                grid.DestroyBox();
                Debug.Log("Sama");
            }
            else
            {
                Debug.Log("Tidak sama");
            }
        }
    }
}
