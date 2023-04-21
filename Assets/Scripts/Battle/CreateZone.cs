using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateZone : MonoBehaviour
{
    List<Image> images = new List<Image>();
    public MonstresBase monster;
    //public List<List<int>> AllAttackPosition = new List<List<int>>();
    List<Bloc> blocs = new List<Bloc>();
    public Button NextAction, EndOfFight;
    public Canvas canvas;
    public Image oneBloc;
    int NbrBlocLength;
    int NbrBlocWidth;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(canvas.GetComponent<RectTransform>().rect.width);
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
                Image bloc = Instantiate(oneBloc, new Vector3(SixeX * j + SixeX / 2, SixeY * i + SixeY / 2, 0), Quaternion.identity);
                bloc.rectTransform.sizeDelta = new Vector2(SixeX, SixeY );
                bloc.transform.SetParent(canvas.transform, true);
                bloc.transform.SetSiblingIndex(0);

                Bloc newBloc = gameObject.AddComponent<Bloc>();
                newBloc.X = i;
                newBloc.Y = j;
                newBloc.image = bloc;
                blocs.Add(newBloc);
            }
        }
        StartCoroutine(Illumine());
       

    }
    IEnumerator Illumine()
    {
        Move theMove = monster.moves[Random.Range(0, monster.moves.Length)];
        int imageBase = Random.Range(0, blocs.Count);
        Bloc lage = blocs[imageBase];
        lage.image.color = Color.red;
        foreach (Bloc allBlocs in blocs)
        {
           for(int i = 0; i < theMove.X.Count; i++)
            {
                if(allBlocs.X == lage.X+ theMove.X[i] && allBlocs.Y == lage.Y + theMove.Y[i])
                {
                    allBlocs.image.color = Color.red;
                }
            }
            
            yield return new WaitForSeconds(.1f);
        }
        
    }
    //Permet de détruire la zone actuel, afin de vider l'écran
    public void DestroyZone()
    {
        //on supprime tout les blocs actuels
        foreach(Transform zoneBloc in canvas.transform)
        {
            Destroy(zoneBloc.gameObject);
        }
        //On va vider notre liste afin de pouvoir la remplir à nouveau
        //le ToList ici nous permet de créer une liste qui aura toutes les réferences des blocs dans notre liste actuelle, ainsi on évite à la liste actuelle de ne pas trouver les références des blmocs qu'on aurait effacé precedemment 
        foreach (Bloc allBlocs in blocs.ToList())
        {
            blocs.Remove(allBlocs);
        }
        StartCoroutine(testZone());
    }
    public void newAction()
    {
        foreach (Bloc allBlocs in blocs.ToList())
        {
            allBlocs.image.color = Color.white;
        }
        StartCoroutine(Illumine());
    }
    IEnumerator testZone()
    {
        yield return new WaitForSeconds(2f);
        InitZone("small");
    }
}
