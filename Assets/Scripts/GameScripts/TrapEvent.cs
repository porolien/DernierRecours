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

        trapEventText.SetText("Vous �tes tomb�s dans un pi�ge, avez-vous une grenade afin de le d�truire ?");
    }

    public void DeactivateTrapEvent()
    {

        TrapEventCanva.gameObject.SetActive(false);
        finalButton.gameObject.SetActive(false);
    }



    // Destroy or not the Trap
    public void YesButton()
    {

        trapEventText.SetText("Vous avez choisi de faire exploser le pi�ge gr�ce � un grenade");
        finalButton.gameObject.SetActive(true);

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    public void NoButton()
    {

        trapEventText.SetText("Vous n'avez pas d�truit le pi�ge, chaque joueur perd donc 2 Points de vie");
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
