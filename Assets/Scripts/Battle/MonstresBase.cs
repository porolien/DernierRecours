using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "NewAssets/Create new Monster")]
public class MonstresBase : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public int pv;
    public int attack;
    public Move[] moves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    