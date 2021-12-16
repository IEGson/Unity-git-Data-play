using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class TXT_DATA : MonoBehaviour
{
    public InputField[] item_Date = new InputField[3];
    public Text[] Scroll_item_Date = new Text[3];
    void Awake()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Example.txt");
        WriteTxt(filePath, "");
        Debug.Log(ReadTxt(filePath));
    }
    public void SaveDate()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Example.txt");
        if (item_Date[0].text != null && item_Date[1].text != null && item_Date[2].text != null)
        {
            string message =  item_Date[0].text.ToString() + "," + item_Date[1].text.ToString() + "," + item_Date[2].text.ToString();
            WriteTxt(filePath, message);
        }
    }
    public void LoadDate()
    {

        string filePath = Path.Combine(Application.streamingAssetsPath, "Example.txt");
        string[] words = ReadTxt(filePath).Split(',');
        Scroll_item_Date[0].text += "\n" + words[0];
        Scroll_item_Date[1].text += "\n" + words[1];
        Scroll_item_Date[2].text += "\n" + words[2];
        Debug.Log(ReadTxt(filePath));

    }
    //TXT파일 쓰기
    void WriteTxt(string filePath, string message)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }
        //FileMode.OpenOrCreate -> 기존파일이 없으면 생성, 있으면 파일을 열기
        FileStream fileStream
            = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);

        writer.WriteLine(message);
        writer.Close();
    }
    //TXT파일 읽기
    string ReadTxt(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";

        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath);
            value = reader.ReadToEnd();
            reader.Close();
        }

        else
            value = "파일이 없습니다.";

        return value;
    }
}
