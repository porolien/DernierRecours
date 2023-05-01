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
    public List<MonstresBase> AllMonster = new List<MonstresBase>();
    public MonstresBase monster;
    //public List<List<int>> AllAttackPosition = new List<List<int>>();
    List<Bloc> blocs = new List<Bloc>();
    public Button NextAction, EndOfFight;
    public GameObject blocsParent;
    public Image oneBloc;
    public GameObject MonsterSheet;
    public GameObject Map; 
    int NbrBlocLength;
    int NbrBlocWidth;
    public List<Sprite> SmallMaps = new List<Sprite>();
    public List<Sprite> MediumMaps = new List<Sprite>();
    public List<Sprite> LargeMaps = new List<Sprite>();
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
        monster = AllMonster[Random.Range(0, AllMonster.Count)];
        MonsterSheet.GetComponent<Image>().sprite = monster.Sprite;
        float BlocSize = 0;
        float Padding = 0;
        float MinSpawnBlocX = 0;
        float MinSpawnBlocY = 0;
        
        transform.GetChild(0).GetComponent<Image>().sprite = Map.GetComponent<Image>().sprite;
      /*  foreach(Transform child in this.transform)
        {
            if(child.name == "Maps")
            {
                child.
            }
        }*/
        switch (size)
        {
            case "small":
                NbrBlocWidth = 6;
                NbrBlocLength = 4;
                BlocSize = 180;
                Padding = 8;
                MinSpawnBlocX = 410;
                MinSpawnBlocY = 180;
                break;

            case "medium":
                NbrBlocWidth = 8;
                NbrBlocLength = 6;
                BlocSize = 130;
                Padding = 3;
                MinSpawnBlocX = 435;
                MinSpawnBlocY = 150;
                break;

            case "large":
                NbrBlocWidth = 12;
                NbrBlocLength = 8;
                BlocSize = 105;
                Padding = 6;
                MinSpawnBlocX = 303;
                MinSpawnBlocY = 105;
                break;
        }
        for (int i = 0; i < NbrBlocLength; i++)
        {
            for(int j = 0; j < NbrBlocWidth; j++)
            {
                Image bloc = Instantiate(oneBloc, new Vector3( /*  SixeX * j + SixeX / 2  */ BlocSize * j + Padding * j + MinSpawnBlocX + BlocSize/2 - Padding, /*  SixeY * i + SixeY / 2  */ BlocSize * i + Padding * i + MinSpawnBlocY + BlocSize / 2 - Padding, 0), Quaternion.identity);
                bloc.rectTransform.sizeDelta = new Vector2(BlocSize, BlocSize);
                bloc.transform.SetParent(blocsParent.transform, true);
                bloc.transform.SetSiblingIndex(1);
                bloc.gameObject.SetActive(false);
                Bloc newBloc = gameObject.AddComponent<Bloc>();
                newBloc.X = i;
                newBloc.Y = j;
                newBloc.image = bloc;
                blocs.Add(newBloc);
                
            }
        }
        showDangerZone();

        //StartCoroutine(Illumine());


    }

    public void showDangerZone()
    {
        Move theMove = monster.moves[Random.Range(0, monster.moves.Length)];
        int imageBase = Random.Range(0, blocs.Count);
        Bloc lage = blocs[imageBase];
        foreach (Bloc allBlocs in blocs)
        {
            for (int i = 0; i < theMove.X.Count; i++)
            {
                if (allBlocs.X == lage.X + theMove.X[i] && allBlocs.Y == lage.Y + theMove.Y[i])
                {
                    //allBlocs.image.color = Color.red;
                    allBlocs.image.gameObject.SetActive(true);
                }
            }


        }
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
        foreach(Transform zoneBloc in blocsParent.transform)
        {
            if(zoneBloc.gameObject.tag == "Bloc")
            {
                Destroy(zoneBloc.gameObject);
            }
            
        }
        //On va vider notre liste afin de pouvoir la remplir à nouveau
        foreach (Bloc allBlocs in blocs.ToList())
        {
            blocs.Remove(allBlocs);
        }
        gameObject.SetActive(false);
        GameManager.Instance.Newturn();
    }
    public void newAction()
    {
        foreach (Bloc allBlocs in blocs.ToList())
        {
            allBlocs.image.gameObject.SetActive(false);
        }

        showDangerZone();
      //  StartCoroutine(Illumine());
    }

    public void ShowMonsterSheets()
    {
        if(MonsterSheet.activeSelf == true)
        {
            MonsterSheet.SetActive(false);
        }
        else
        {
            MonsterSheet.SetActive(true);
        }
    }
}
