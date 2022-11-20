using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Button level1button;
    [SerializeField] Button level2button;
    [SerializeField] Button level3button;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        level1button.onClick.AddListener(SelectLevel1);
        level2button.onClick.AddListener(SelectLevel2);
        level3button.onClick.AddListener(SelectLevel3);
    }



    void Update()
    {
        if (gameManager.level1Complete) { level2button.interactable = true;}
        if (gameManager.level2Complete) { Debug.Log("level2!"); level3button.interactable = true; }
        if (gameManager.level3Complete) { Debug.Log("game complete!"); }
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
