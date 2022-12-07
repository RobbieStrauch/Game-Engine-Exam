using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionManager : MonoBehaviour
{
    public static ConditionManager instance;

    public GameObject gameOverText;
    public GameObject winnerText;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameOver()
    {
        gameOverText.SetActive(true);
    }

    public void SetWinner()
    {
        winnerText.SetActive(true);
    }
}
