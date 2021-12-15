using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieType {인간, 좀비}
public class SwptScriptable : MonoBehaviour
{
    [SerializeField] 
    private List<scriptableobject> zombieDatas;
    [SerializeField] 
    private GameObject zombiePrefab;
    void Start() 
    {
        for (int i = 0; i < zombieDatas.Count; i++) 
        {
            var zombie = SpawnZombie((ZombieType)i); 
            zombie.WatchZombieInfo(); 
        } 
    }
    public Scriptable_data SpawnZombie(ZombieType type) 
    {
        var newZombie = Instantiate(zombiePrefab).GetComponent<Scriptable_data>(); 
        newZombie.scriptableobject = zombieDatas[(int)type]; 
        return newZombie; 
    }

}
