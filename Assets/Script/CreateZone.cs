using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateZone : MonoBehaviour
{
    List<Image> images = new List<Image>();
    public List<int> X = new List<int>();
    public List<int> Y = new List<int>();
    //public List<List<int>> AllAttackPosition = new List<List<int>>();
    List<Bloc> blocs = new List<Bloc>();
    public Canvas canvas;
    public Image oneBloc;
    int NbrBlocLength;
    int NbrBlocWidth;
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
        
        switch (size)
        {
            case "small":
                NbrBlocWidth = 4;
                NbrBlocLength = 6;
                
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
        for (int i = 0; i < NbrBlocLength; i++)
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
                
               /* switch (i) {
                    case 0:
                        bloc.color = Color.blue;
                        break;
                }
                switch (i)
                {
                    case 1:
                        bloc.color = Color.yellow;
                        break;
                }
                switch (i)
                {
                    case 2:
                        bloc.color = Color.green;
                        break;
                }
                switch (i)
                {
                    case 3:
                        bloc.color = Color.black;
                        break;
                }
                switch (i)
                {
                    case 4:
                        bloc.color = Color.gray;
                        break;
                }
                if (j % 2 == 0)
                {
                    bloc.color = Color.red;
                }*/
                Bloc newBloc = new Bloc();
                newBloc.X = i;
                newBloc.Y = j;
                newBloc.image = bloc;
                blocs.Add(newBloc);
               
                //Debug.Log(bloc.rectTransform.rect.width);
            }
        }
        StartCoroutine(Illumine());
       

    }
    IEnumerator Illumine()
    {
        int imageBase = Random.Range(0, blocs.Count);
        Bloc lage = blocs[imageBase];
        lage.image.color = Color.red;
        foreach (Bloc allBlocs in blocs)
        {
           for(int i = 0; i < X.Count; i++)
            {
                if(allBlocs.X == lage.X+X[i] && allBlocs.Y == lage.Y+Y[i])
                {
                    allBlocs.image.color = Color.red;
                }
            }
            
            yield return new WaitForSeconds(.1f);
        }
        
    }
}
