using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingScoreDisplay : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] int ballHealthFinal;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore()
    {
        scoreKeeper.ModifyHealth(10.35f);

    }
}
