using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardEvent : MonoBehaviour
{
    public GameObject rewardEventCanva;
    public TextMeshProUGUI rewardText;

    int randomInt = 0;
    string rewardTextSetter;

    // Start is called before the first frame update
    void Start()
    {

        rewardEventCanva.SetActive(false);
    }


    public void ActivateRewardEvent()
    {
        rewardEventCanva.SetActive(true);
        randomInt = Random.Range(0, 1);

        // Choose which reward and which number of it
        if (randomInt == 0)
        {
            randomInt = Random.Range(1, 2);

            rewardTextSetter = "Piochez : " + randomInt + " carte(s) équipement(s)";
            rewardText.SetText(rewardTextSetter);
        }

        else
        {
            randomInt = Random.Range(1, 2);

            rewardTextSetter = "Piochez : " + randomInt + " carte(s) consommables(s)";
            rewardText.SetText(rewardTextSetter);
        }
    }

    public void DeactivateRewardEvent()
    {

        rewardEventCanva.SetActive(false);
        GameManager.Instance.Newturn();
    }
}
