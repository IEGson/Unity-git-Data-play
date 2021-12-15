using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptable_data : MonoBehaviour
{
    [SerializeField]
    private scriptableobject scripte;
    public scriptableobject scriptableobject { set { scripte = value; } }
    public void WatchZombieInfo() 
    {
        Debug.Log("이름 :: " + scripte.Id); 
        Debug.Log("상태 :: " + scripte.NAME);
        Debug.Log("수치 :: " + scripte.DIS); 
    }

}
