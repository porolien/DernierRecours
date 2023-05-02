using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEvent : MonoBehaviour
{
    public List<string> PrimaryEvent = new List<string>();
    public int PrimaryEventIndex = 1;

    public TrapEvent trapEvent;
    public ChoiceEvent choiceEvent;
    public RewardEvent rewardEvent;
    public GameObject PrimaryCanva;
    public GameObject battleEventCanva;
    public CreateZone createZone;
    public void Start()
    {
        GameManager.Instance.primaryCanva = PrimaryCanva;
    }


    public void Event()
    {
        GameManager.Instance.NumberOfTurn++;

        if (GameManager.Instance.NumberOfTurn <= GameManager.Instance.MaxTurn)
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
                battleEventCanva.SetActive(true);
                string sizeMap = "";
                switch (Random.Range(0, 3))
                {
                    case 0:
                        sizeMap = "small";
                        createZone.Map.GetComponent<Image>().sprite = createZone.SmallMaps[Random.Range(0, createZone.SmallMaps.Count)];
                        break;

                    case 1:
                        sizeMap = "medium";
                        createZone.Map.GetComponent<Image>().sprite = createZone.MediumMaps[Random.Range(0, createZone.MediumMaps.Count)];
                        break;

                    case 2:
                        sizeMap = "large";
                        createZone.Map.GetComponent<Image>().sprite = createZone.LargeMaps[Random.Range(0, createZone.LargeMaps.Count)];
                        break;
                }
                createZone.InitZone(sizeMap);
                PrimaryCanva.gameObject.SetActive(false);
            }
        }
        

     
    }


}
