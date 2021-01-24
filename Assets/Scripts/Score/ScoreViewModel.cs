using Effect;
using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreViewModel : MonoBehaviour
    {
        [SerializeField] private int comboStep;
        
        public ScoreModel scoreModel;

        /// <summary>
        /// Add score 
        /// </summary>
        /// <param name="value">Additional score</param>
        /// <param name="scoreText">Score Text Mesh Pro</param>
        public void AddScore(int value, TextMeshProUGUI scoreText)
        {
            int currentScore = scoreModel.score;
            scoreModel.score += value + (int)((scoreModel.combo - 0.5)*10);
            
            // Add number effect
            StartCoroutine(AddNumberEffect.AddNumber(currentScore, 
                scoreModel.score, scoreText, 0.01f));
        }
        
        /// <summary>
        /// Set combo number and message
        /// </summary>
        /// <param name="comboMessageText"></param>
        public void SetComboMessage(TextMeshProUGUI comboMessageText)
        {
            if (scoreModel.combo % comboStep == 0 && scoreModel.combo != 0)
            {
                Debug.Log(scoreModel.combo);
                // Set index between 0 - comboMessage.Count
                int index = (scoreModel.combo / comboStep - 1) % scoreModel.comboMessage.Count;
                
                comboMessageText.text = $"{scoreModel.comboMessage[index]}\n" +
                                        $"Combo x{scoreModel.combo}";
            }
        }
    }
}