using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEvent : MonoBehaviour
{
    public List<string> PrimaryEvent = new List<string>();
    public int PrimaryEventIndex = 1;

    public TrapEvent trapEvent;
    public ChoiceEvent choiceEvent;
    public RewardEvent rewardEvent;

    public GameObject PrimaryCanva;

    public void Start()
    {
        GameManager.Instance.primaryCanva = PrimaryCanva;
    }


    public void Event()
    {
        PrimaryEventIndex = Random.Range(0, PrimaryEvent.Count);


        // Trap Event :
        if (PrimaryEvent[PrimaryEventIndex] == PrimaryEvent[0])
        {

            // Debug.Log("Trap");
            trapEvent.ActivateTrapEvent();
            PrimaryCanva.gameObject.SetActive(false);
        }

        // Choice Event :
        if (PrimaryEvent[PrimaryEventIndex] == PrimaryEvent[1])
        {

            // Debug.Log("Choice");
            choiceEvent.ActivateChoiceEvent();
            PrimaryCanva.gameObject.SetActive(false);
        }

        // Reward Event :
        if (PrimaryEvent[PrimaryEventIndex] == PrimaryEvent[2])
        {

            // Debug.Log("Reward");
            rewardEvent.ActivateRewardEvent();
            PrimaryCanva.gameObject.SetActive(false);
        }

        // Fight Event
        if (PrimaryEvent[PrimaryEventIndex] == PrimaryEvent[3])
        {
            Debug.Log("Duel");

        }

        // WorldEvent Event
        if (PrimaryEvent[PrimaryEventIndex] == PrimaryEvent[4])
        {
            Debug.Log("World Event");

        }
    }


}
