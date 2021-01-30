using System;
using System.Collections;
using Effect;
using Score;
using TMPro;
using UnityEngine;
using Grid = Box.Grid;

namespace Inputs
{
    public class LeftRightButtonHandler : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private TextMeshProUGUI scoreText,
            comboMessageText;
        [SerializeField] private GameObject wrongPanel;
        [SerializeField] private Sprite leftGroundSprite,
            rightGroundSprite;
        [SerializeField] private ScoreViewModel scoreViewModel;
        [SerializeField] private Animator comboTextAnimator;
        
        private const int LeftSpriteIndex = 0,
            RightSpriteIndex = 1;

        #region PUBLIC_METHODS
        
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
                ChangeGroundSprite(correctBox);
                grid.DestroyBox();
                scoreViewModel.AddScore(10, scoreText);
                scoreViewModel.scoreModel.combo++;
                SetCombo();
            }
            else
            {
                scoreViewModel.scoreModel.combo = 0;
                SetCombo();
                StartCoroutine(ShowWrongPanel(2));
            }
        }
        
        #endregion

        #region PRIVATE_METHODS
        
        /// <summary>
        /// Change Ground Sprite 
        /// </summary>
        /// <param name="correctBox"></param>
        private void ChangeGroundSprite(int correctBox)
        {
            switch (correctBox)
            {
                case LeftSpriteIndex:
                    GroundEffect.ChangeGroundImage(leftGroundSprite);
                    break;
                case RightSpriteIndex:
                    GroundEffect.ChangeGroundImage(rightGroundSprite);
                    break;
                default:
                    Debug.LogWarning($"Box {correctBox} is not in list");
                    break;
            }
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
        /// Set combo text
        /// </summary>
        private void SetCombo()
        {
            scoreViewModel.SetComboMessage(comboMessageText, comboTextAnimator);
        }
        
        #endregion
    }
}
