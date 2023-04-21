using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "NewAssets/Create new Move")]
public class Move : ScriptableObject
{
    public List<int> X = new List<int>();
    public List<int> Y = new List<int>();
    public string moveName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
