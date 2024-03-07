using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MicrogameInputEvents
{

    TextMeshProUGUI scoreLabel;
    float score;

    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        scoreLabel.text = "Combos Completed: " + score;
    }

    public void ScoreIncrease()
    {
        score += 1;
    }
}
