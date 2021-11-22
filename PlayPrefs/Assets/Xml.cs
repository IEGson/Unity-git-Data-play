using System.Collections;
using System.Collections.Generic;
using System.Xml; // xml 전처리문 
using UnityEngine;
using UnityEngine.UI;


public class Xml : MonoBehaviour
{
    public Text[] TEST_TEXT = new Text[3];
    // Start is called before the first frame update
    void Start()
    {
      
    }
    public void CreateXml() // xml 파일 생성 
    {
        XmlDocument xmlDoc = new XmlDocument();

        // Xml을 선언한다(xml의 버전과 인코딩 방식을 정해준다.)
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        // 루트 노드 생성
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
        xmlDoc.AppendChild(root);

        // 자식 노드 생성
        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
        root.AppendChild(child);

        // 자식 노드에 들어갈 속성 생성
        XmlElement name = xmlDoc.CreateElement("Name");
        name.InnerText = "hi";
        child.AppendChild(name);

        XmlElement lv = xmlDoc.CreateElement("Level");
        lv.InnerText = "1";
        child.AppendChild(lv);

        XmlElement exp = xmlDoc.CreateElement("Experience");
        exp.InnerText = "45";
        child.AppendChild(exp);
        xmlDoc.Save(Application.persistentDataPath + @"Character.xml");

        //xmlDoc.Save("./Assets/Resources/Character.xml");
    }
    public void LoadXml() // 데이터 저장하기 
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        Debug.Log(textAsset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

        foreach (XmlNode node in nodes)
        {
            TEST_TEXT[0].text = node.SelectSingleNode("Name").InnerText;
            TEST_TEXT[1].text = node.SelectSingleNode("Level").InnerText;
            TEST_TEXT[2].text = node.SelectSingleNode("Experience").InnerText;

            //Debug.Log("Name :: " + node.SelectSingleNode("Name").InnerText);
            //Debug.Log("Level :: " + node.SelectSingleNode("Level").InnerText);
            //Debug.Log("Exp :: " + node.SelectSingleNode("Experience").InnerText);
        }
    }
    public void SaveOverlapXml() // 저장된 데이터 덮어 씌우기 
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
        XmlNode character = nodes[0];

        character.SelectSingleNode("Name").InnerText = "wergia";
        character.SelectSingleNode("Level").InnerText = "4";
        character.SelectSingleNode("Experience").InnerText = "120";

        xmlDoc.Save("./Assets/Resources/Character.xml");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9)) // xml파일  생성
        {
            CreateXml();
        }
        if (Input.GetKeyDown(KeyCode.F10)) // xml 파일 읽기
        {
            LoadXml();
        }
        if (Input.GetKeyDown(KeyCode.F11)) 
        {
            SaveOverlapXml();
        }
    }
}
