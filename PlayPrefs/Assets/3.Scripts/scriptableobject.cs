using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "스크립트 데이터", menuName = "데이터")]
public class scriptableobject : ScriptableObject
{
    //데이터 저장형태 지정
    //게임에서 캐릭터 HP나 적의 HP 등을 관리하는 정보를 사용하는데 사용
    [SerializeField]
    private string ID;
    public string Id { get { return ID; } }
    [SerializeField]
    private string Name;
    public string NAME { get { return Name;} }
    [SerializeField]
    private int Dis;
    public int DIS { get { return Dis; } }

    
}
