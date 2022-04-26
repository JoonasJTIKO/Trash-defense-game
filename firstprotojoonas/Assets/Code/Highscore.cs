using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace towerdefense
{
    public class Highscore : MonoBehaviour
    {
        [SerializeField]
        private int levelNumber;

        [SerializeField]
        private TMP_Text text;
        private int score = 0;
        private int highscore;

        void Start()
        {
            highscore = PlayerPrefs.GetInt($"highscore_{levelNumber}", highscore);
            if(text != null)
            {
                text.text = "record: " + highscore.ToString();
            }
        }

        public void ScoreAdd()
        {
            score++;
            if(score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt($"highscore_{levelNumber}", highscore);
            }
        }
    }
}
