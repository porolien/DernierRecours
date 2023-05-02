using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrapEvent : MonoBehaviour
{
    public GameObject TrapEventCanva;

    public TextMeshProUGUI trapEventText;

    public GameObject yesButton;
    public GameObject noButton;
    public Button finalButton;

    // Start is called before the first frame update
    void Start()
    {

        TrapEventCanva.gameObject.SetActive(false);
        finalButton.gameObject.SetActive(false);
    }

    
    public void ActivateTrapEvent()
    {

        TrapEventCanva.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        trapEventText.SetText("You fell in a trap ! Do you want to explode it with a Grenade?");
    }

    public void DeactivateTrapEvent()
    {

        TrapEventCanva.gameObject.SetActive(false);
        finalButton.gameObject.SetActive(false);
    }



    // Destroy or not the Trap
    public void YesButton()
    {

        trapEventText.SetText("You choose to explode the trap with a Grenade.");
        finalButton.gameObject.SetActive(true);

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    public void NoButton()
    {

        trapEventText.SetText("You didn't destroy the trap, each player takes 2 damages");
        finalButton.gameObject.SetActive(true);

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }



    // Completes the Trap Event and launch a new turn
    public void ContinueButton()
    {

        DeactivateTrapEvent();
        GameManager.Instance.Newturn();
    }
}
