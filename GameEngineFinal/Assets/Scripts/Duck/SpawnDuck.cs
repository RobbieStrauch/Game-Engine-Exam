using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDuck : MonoBehaviour
{
    public static SpawnDuck instance;
    public List<GameObject> Ducks;

    private float timer = 0f;
    private float spawnTime = 1f;

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
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            for (int i = 0; i < Ducks.Count; i++)
            {
                if (!Ducks[i].activeSelf)
                {
                    Ducks[i].transform.position = new Vector3(Random.Range(-10f, 10f), 0.25f, Random.Range(-10f, 10f));
                    Ducks[i].SetActive(true);
                    break;
                }
                if (i == Ducks.Count - 1 && Ducks[i].activeSelf)
                {
                    ConditionManager.instance.SetGameOver();
                    //Debug.Log("Too Many Ducks! Game Over You Lose!");
                    Time.timeScale = 0f;
                    break;
                }
            }

            timer = 0f;
        }
    }
}
