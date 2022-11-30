using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    GameManager gameManager;
    ScoreKeeper scoreKeeper;
    [SerializeField] Button level1button;
    [SerializeField] Button level2button;
    [SerializeField] Button level3button;

    [SerializeField] TextMeshProUGUI level1Scores;
    [SerializeField] TextMeshProUGUI level2Scores;
    [SerializeField] TextMeshProUGUI level3Scores;

    [SerializeField] TextMeshProUGUI LevelSelectMenu;
    [SerializeField] TextMeshProUGUI GameCompleteMenu;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
        level1button.onClick.AddListener(SelectLevel1);
        level2button.onClick.AddListener(SelectLevel2);
        level3button.onClick.AddListener(SelectLevel3);
    }
    void Update()
    {
        if (gameManager.level1Complete) {
            level1Scores.text = "Level 1:\nEnemies Defeated: " + scoreKeeper.level1EnemiesDefeated + "\n" +
                                "Gold Collected: " + scoreKeeper.level1GoldTotal + "\n" +
                                "Health: " + scoreKeeper.level1BallHealthFinal + "%";
            level2button.interactable = true;
        }
        if (gameManager.level2Complete) 
        {
            level2Scores.text = "Level 2:\nEnemies Defeated: " + scoreKeeper.level2EnemiesDefeated + "\n" +
                                "Gold Collected: " + scoreKeeper.level2GoldTotal + "\n" +
                                "Health: " + scoreKeeper.level2BallHealthFinal + "%";
            level3button.interactable = true; 
        }
        if (gameManager.level3Complete) 
        {
            level3Scores.text = "Level 2:\nEnemies Defeated: " + scoreKeeper.level3EnemiesDefeated + "\n" +
                                "Gold Collected: " + scoreKeeper.level3GoldTotal + "\n" +
                                "Health: " + scoreKeeper.level3BallHealthFinal + "%";
            LevelSelectMenu.enabled = false;
            GameCompleteMenu.enabled = true;
        }
    }
    private void SelectLevel1()
    {
        gameManager.LoadScene("Level1");
    }
    private void SelectLevel2()
    {
        gameManager.LoadScene("Level2");
    }
    private void SelectLevel3()
    {
        gameManager.LoadScene("Level3");
    }

}
