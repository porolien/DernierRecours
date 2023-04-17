using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenesWithButton : MonoBehaviour
{
    public string SceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(SceneName);

    }


    public void LaunchGame()
    {
        if (GameManager.Instance.DifficultyIndex != 0)
        {
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            Debug.Log($"Le nombre de joueur n'est pas sélectionné, actuellement {GameManager.Instance.DifficultyIndex}");
        }
    }
}
