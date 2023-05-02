using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("GameManager is null");
            return _instance;
        }
    }

    public int NumberOfTurn = 0;
    public int MaxTurn = 0;
    public int DifficultyIndex = 0;
    public GameObject primaryCanva;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

/*
    // Set Difficulty of the game
    public void EasyDifficulty()
    {
        DifficultyIndex = 1;
    }

    public void MediumDifficulty()
    {
        DifficultyIndex = 2;
    }

    public void HardDifficulty()
    {
        DifficultyIndex = 3;
    }
*/

    // Set number of Max Turns
    public void FastGame()
    {
        MaxTurn = 5;
    }
    public void NormalGame()
    {
        MaxTurn = 10;
    }
    public void SlowGame()
    {
        MaxTurn = 15;
    }


    // Launch a new turn after all the events
    public void Newturn()
    {
        primaryCanva.gameObject.SetActive(true);
    }

}


