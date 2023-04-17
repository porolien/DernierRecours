using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Mob : MonoBehaviour
{
    public int MobHealth = 20;
    public int AtkDamage = 2;


    void Start()
    {
        Debug.Log("start");
        Debug.Log(GameManager.Instance);
        if (GameManager.Instance.DifficultyIndex == 1)
        {
            Debug.Log("1");
            MobHealth += 2;
            AtkDamage += 2;
        }
        else if (GameManager.Instance.DifficultyIndex == 2)
        {
            Debug.Log("2");
            MobHealth += 4;
            AtkDamage += 4;

        }
    }
}