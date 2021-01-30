using Effect;
using Score;
using TMPro;
using UnityEngine;

namespace Game_Over
{
    public class GameOverScript : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private ScoreViewModel scoreViewModel;
        
        private int initialScore;

        private void OnEnable()
        {
            int targetScore = scoreViewModel.scoreModel.score;
            StartCoroutine(AddNumberEffect.AddNumber(initialScore,
                targetScore, scoreText, 0.02f));

            initialScore = targetScore;
        }
    }
}
