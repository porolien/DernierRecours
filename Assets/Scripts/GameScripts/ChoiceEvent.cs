using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class ChoiceEvent : MonoBehaviour
{
    public GameObject ChoiceEventCanva;

    public List<string> Sentences = new List<string>();
    public TextMeshProUGUI Text;
    string baseText = "You can choose to do ";

    public List<string> ChoiceConsequences= new List<string>();
    public int ChoiceConsequencesIndex = 0;

    public TrapEvent trapEvent;
    public RewardEvent rewardEvent;
    
    void Start()
    {
        ChoiceEventCanva.gameObject.SetActive(false);
    }

    // When Choice Event occurs, enables the choice event 
    public void ActivateChoiceEvent()
    {
        ChoiceEventCanva.gameObject.SetActive(true);
        Text.text = baseText + Sentences[Random.Range(0, Sentences.Count)];
    }

    // when the choice is made, disable the choice event
    public void DeactivateChoiceEvent()
    {
        ChoiceEventCanva.gameObject.SetActive(false) ;
    }


    // Choices made by the player
    public void FirstEvent()
    {
        PlayerChoiceEvent();
    }

    public void SecondEvent()
    {
        PlayerChoiceEvent();
    }



    // CHoices that can be randomly choose by the player
    public void PlayerChoiceEvent()
    {
        ChoiceConsequencesIndex = Random.Range(0, ChoiceConsequences.Count);
        if (ChoiceConsequences[ChoiceConsequencesIndex] == ChoiceConsequences[0])
        {
            // Trap Event 
            ChoiceEventCanva.gameObject.SetActive(false);
            trapEvent.ActivateTrapEvent();

            // Debug.Log("Trap");
        }

        if (ChoiceConsequences[ChoiceConsequencesIndex] == ChoiceConsequences[1])
        {
            // Reward Event 
            ChoiceEventCanva.gameObject.SetActive(false);
            rewardEvent.ActivateRewardEvent();

            // Debug.Log("Reward");
        }

        if (ChoiceConsequences[ChoiceConsequencesIndex] == ChoiceConsequences[2])
        {
            // Nothing
            DeactivateChoiceEvent();
            GameManager.Instance.Newturn();

            // Debug.Log("Nothing");
        }
    }
}
