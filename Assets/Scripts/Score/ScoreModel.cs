using System;
using System.Collections.Generic;

namespace Score
{
    [Serializable]
    public class ScoreModel
    {
        public int score, 
            combo;
        
        public List<string> comboMessage; 
    }
}