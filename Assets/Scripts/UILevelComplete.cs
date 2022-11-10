using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelComplete : MonoBehaviour
{
    [Header("FinalHealth")]
    [SerializeField] TextMeshProUGUI finalHealthText;
    [Header("FinalGold")]
    [SerializeField] TextMeshProUGUI finalGoldText;
    [Header("FinalEnemyCount")]
    [SerializeField] TextMeshProUGUI finalEnemyText;
    
    ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        finalHealthText.text = "Health remaining: "+ scoreKeeper.GetHealth().ToString("0.0") + "%";
    }
}
