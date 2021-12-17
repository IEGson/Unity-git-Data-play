using System.Collections;
using System.Collections.Generic; //list 사용하기 위해 선언 
using UnityEngine;
using UnityEngine.UI;
using LitJson; // json 사용하기위해 선언 LitJson.dll파일이 있어야합니다.
using System.IO; // json 파일을 열고 닫기 위해서 선언 

public class Item<T> //제너릭 사용
{
    public T ID;        //id
    public T Name;  // 이름
    public T Dis;   // 설명 
    public Item(T id, T name, T dis)
    {
        ID = id;
        Name = name;
        Dis = dis;
    }
}
public class jsontest : MonoBehaviour
{

    /// <summary>
    /// JsonUtility : 유니티에서 json date 생성 TojSON /  덮어쓰기 FromJsonOverwrite / 만들기 FromJson
    ///  ToJson()을 사용하여 변환(직렬화), FromJson()을 사용하여 역변환(역직렬화)한다. 
    /// </summary>
    public InputField[] item_Date = new InputField[3];
    public Text[] Scroll_item_Date = new Text[3];

    public List<Item<string>> itemlist = new List<Item<string>>(); // class 아이템에 있는 id와 name, dis을 리스트  전체 아이템리스트
    private string jsonstring;
    //json 데이터 저장
    public void savefunc()
    {
        //데이터 추가
        if (item_Date[0].text != null && item_Date[1].text != null && item_Date[2].text != null)
        {
            itemlist.Add(new Item<string>(item_Date[0].text, item_Date[1].text, item_Date[2].text));// 0번째에 id와 name, dis에 값을 추가하겠다.

        }
        JsonData itemjson = JsonMapper.ToJson(itemlist); //itemlist의 데이터를 json데이터로 만드는 부분 (json데이터 쓰기)
        File.WriteAllText(Application.dataPath + "/Resources/itemdata.json", itemjson.ToString()); //json 파일 생성 
    }
    //json 데이터 불러오기
    public void loadfunc()
    {  
         StartCoroutine(loadco());
    }
    IEnumerator loadco()
    {
        string jsonstring = File.ReadAllText(Application.dataPath + "/Resources/itemdata.json");        
        JsonData itemdata = JsonMapper.ToObject(jsonstring); // id, name, dis로 구별할수있게 선언 
        //저장되어 있는 파일이 있으면  JsonData itemdata = JsonMapper.ToObject(jsonstring);
        //저장되어 있는 파일이 없으면   JsonData itemdata = JsonMapper.ToObject(itemlist); 로 직접 아이템과 연결 
        Parsingjsonitem(itemdata); // 파싱함수 선언
        yield return null;
    }
    // Update is called once per frame
    private void Parsingjsonitem(JsonData name)// 파싱할 데이터를 입력을 선언(name)
    {
        for (int i = 0; i < name.Count; i++) //이름선언이 갯수 까지 나타내겠다.
        {
            Scroll_item_Date[0].text += "\n" + name[i]["ID"].ToString();
            Scroll_item_Date[1].text += "\n" + name[i]["Name"].ToString();
            Scroll_item_Date[2].text += "\n" + name[i]["Dis"].ToString();

        }

    }
}
