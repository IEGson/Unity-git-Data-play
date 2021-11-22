using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "새로운 카드", menuName = "카드/미니언")]
public class scriptableobject : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;

    public int manaCost;
    public int attack;
    public int health;
    public void Print()
    {
        Debug.Log(name + ": " + description + " 카드의 비용: " + manaCost);
    }
    
}
