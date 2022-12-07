using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int highestScore = 10;

    private bool invertOn = false;
    private float invertTimer = 0f;
    private float invertAmountTime = 5f;

    private int score = 0;
    private int missDuckCounter = 0;

    ICommand command;

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
        if (score == highestScore)
        {
            ConditionManager.instance.SetWinner();
            //Debug.Log("Congrats You Win!");
            Time.timeScale = 0f;
        }

        if (missDuckCounter == 2 && !invertOn)
        {
            Debug.Log("Bind Controller");

            command = new PlaceInvertCommand(true);
            command.Execute();
            CommandInvoker.AddCommand(command);
            invertOn = true;

            ResetMiss();
        }

        if (invertOn)
        {
            invertTimer += Time.deltaTime;
            if (invertTimer >= invertAmountTime)
            {
                command = new PlaceInvertCommand(false);
                command.Execute();
                CommandInvoker.AddCommand(command);

                invertTimer = 0f;
                invertOn = false;
            }
        }
    }

    public void AddScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddMiss()
    {
        missDuckCounter++;
    }

    public int GetMiss()
    {
        return missDuckCounter;
    }

    public void ResetMiss()
    {
        missDuckCounter = 0;
    }
}
