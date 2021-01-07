using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Grid = Box.Grid;

namespace Inputs
{
    public class LeftRightButtonHandler : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private Text scoreText;
        [SerializeField] private GameObject wrongPanel;
        
        private int score;

        private void Start()
        {
            score = 0;
        }

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
                AddScore(10);
            }
            else
            {
                StartCoroutine(ShowWrongPanel(2));
            }
        }

        private void AddScore(int value)
        {
            score += value;
            scoreText.text = score.ToString();
        }

        private IEnumerator ShowWrongPanel(float delayTime)
        {
            wrongPanel.SetActive(true);
            yield return new WaitForSeconds(delayTime);
            wrongPanel.SetActive(false);
        }
    }
}
