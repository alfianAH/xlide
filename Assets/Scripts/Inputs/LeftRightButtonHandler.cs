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
        [SerializeField] private Text scoreText,
            comboText;
        [SerializeField] private GameObject wrongPanel;
        
        private int score, combo;

        private void Start()
        {
            score = combo = 0;
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
                combo++;
                SetCombo(true);
            }
            else
            {
                combo = 0;
                SetCombo(false);
                StartCoroutine(ShowWrongPanel(2));
            }
        }
        
        /// <summary>
        /// Add score 
        /// </summary>
        /// <param name="value">Additional score</param>
        private void AddScore(int value)
        {
            score += value + (int)((combo - 0.5)*10);
            scoreText.text = score.ToString();
        }
        
        /// <summary>
        /// Penalty if user input is false
        /// </summary>
        /// <param name="delayTime"></param>
        /// <returns>Wait for delay time</returns>
        private IEnumerator ShowWrongPanel(float delayTime)
        {
            wrongPanel.SetActive(true);
            yield return new WaitForSeconds(delayTime);
            wrongPanel.SetActive(false);
        }
        
        /// <summary>
        /// Set combo text and isActive
        /// </summary>
        /// <param name="isActive"></param>
        private void SetCombo(bool isActive)
        {
            comboText.text = $"Combo x{combo}";
            comboText.gameObject.SetActive(isActive);
        }
    }
}
