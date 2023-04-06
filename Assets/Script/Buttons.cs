using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public CreateZone createZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ExitFight()
    {
        createZone.DestroyZone();
    }

    public void NextAction()
    {
        createZone.newAction();
    }

}
