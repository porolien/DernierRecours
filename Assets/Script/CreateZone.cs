using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateZone : MonoBehaviour
{
     List<Image> images = new List<Image>();
    public Canvas canvas;
    public Image oneBloc;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(canvas.GetComponent<RectTransform>().rect.width);
        // InitZone("small");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitZone(string size)
    {
        int NbrBlocLength = 0;
        int NbrBlocWidth = 0;
        switch (size)
        {
            case "small":
                NbrBlocWidth = 4;
                NbrBlocLength = 5;
                break;

            case "medium":
                NbrBlocWidth = 5;
                NbrBlocLength = 8;
                break;

            case "large":
                NbrBlocWidth = 6;
                NbrBlocLength = 11;
                break;
        }
        for(int i = 0; i < NbrBlocLength; i++)
        {
            for(int j = 0; j < NbrBlocWidth; j++)
            {
                
                float SixeX = canvas.GetComponent<RectTransform>().rect.width / NbrBlocWidth;
                float SixeY = canvas.GetComponent<RectTransform>().rect.height / NbrBlocLength;
                Debug.Log(canvas.GetComponent<RectTransform>().rect.width/NbrBlocWidth);
                Debug.Log(canvas.GetComponent<RectTransform>().rect.height/NbrBlocLength);
                Image bloc = Instantiate(oneBloc, new Vector3(SixeX * j + SixeX / 2, SixeY * i + SixeY / 2, 0), Quaternion.identity);
                bloc.rectTransform.sizeDelta = new Vector2(SixeX, SixeY );
                //Debug.Log(i);
                //Debug.Log(SixeY);
                //Debug.Log(SixeX * i + SixeX / 2);
                /*bloc.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SixeX);
                 bloc.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SixeY);*/
                bloc.transform.SetParent(canvas.transform, true);
                images.Add(bloc);
                //Debug.Log(bloc.rectTransform.rect.width);
            }
        }
        
    }
}
