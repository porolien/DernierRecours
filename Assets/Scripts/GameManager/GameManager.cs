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

            

    public int DifficultyIndex = 0;  

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }
    public void EasyDifficulty()
    {
        DifficultyIndex = 0;
    }

    public void MediumDifficulty()
    {
        DifficultyIndex = 1;
    }

    public void HardDifficulty()
    {
        DifficultyIndex = 2;
    }
}
