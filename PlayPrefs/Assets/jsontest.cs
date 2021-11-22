using System.Collections;
using System.Collections.Generic; //list 사용하기 위해 선언 
using UnityEngine;
using UnityEngine.UI;
using LitJson; // json 사용하기위해 선언 
using System.IO; // json 파일을 열고 닫기 위해서 선언 
public class Item //아이템
{
    public int ID;
    public string Name;
    public string Dis; // 설명 
    public Item(int id, string name, string dis)
    {
        ID = id;
        Name = name;
        Dis = dis;
    }
}
public class jsontest : MonoBehaviour
{
    public Text[] nmasd = new Text[3];
    public List<Item> itemlist = new List<Item>(); // class 아이템에 있는 id와 name, dis을 리스트  전체 아이템리스트
    public List<Item> Inventroy = new List<Item>(); // 내가 소지한 아이템 리스스 
    // Start is called before the first frame update
    void Start()
    {
        itemlist.Add(new Item(0, "a", "A")); // 0번째에 id와 name, dis에 값을 추가하겠다. 
        itemlist.Add(new Item(1, "b", "B"));
        itemlist.Add(new Item(2, "c", "C"));
        itemlist.Add(new Item(3, "d", "D"));
        itemlist.Add(new Item(4, "e", "E"));
        itemlist.Add(new Item(5, "f", "F"));
    }
    public void savefunc()
    {
        /*for (int i = 0; i < itemlist.Count; i++)
        {
            Debug.Log(itemlist[i].ID);
        }*/
        JsonData itemjson = JsonMapper.ToJson(itemlist); //itemlist의 데이터를 json데이터로 만드는 부분 (json데이터 쓰기)
        //File.WriteAllText(Application.dataPath + "/Resources/itemdata.json", itemjson.ToString()); //json 파일 생성 
        File.WriteAllText(Application.persistentDataPath + "itemdata.json", itemjson.ToString()); //json 파일 생성 
    }
    public void loadfunc()
    {
        StartCoroutine(loadco());
    }
    IEnumerator loadco()
    {
        //string jsonstring = File.ReadAllText(Application.dataPath + "/Resources/itemdata.json");
        string jsonstring = File.ReadAllText(Application.persistentDataPath + "itemdata.json");
        Debug.Log(jsonstring);
        nmasd[0].text = jsonstring;
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
            Debug.Log(name[i]["Name"]); // 선언한수의 Name값을 가져오겠다.
            string temp = name[i]["Name"].ToString();
            nmasd[1].text = temp;
            for (int j = 0; j < itemlist.Count; j++) //이름선언이 갯수 까지 나타내겠다.
            {
                if (temp == itemlist[j].Name.ToString())
                {
                    Inventroy.Add(itemlist[i]);
                }
            }
        }
        for (int i = 0; i < Inventroy.Count; i++) //이름선언이 갯수 까지 나타내겠다.
        {
            nmasd[2].text = Inventroy[i].ID.ToString();
            Debug.Log(Inventroy[i].ID); // 선언한수의 Name값을 가져오겠다.
        }
    }
}
