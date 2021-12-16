using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using UnityEngine.UI;
public class INIData : MonoBehaviour
{
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    static extern long WritePrivateProfileString(
         string Section, string Key, string Value, string FilePath);
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    static extern int GetPrivateProfileString(
        string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

    [Header("Write")]
    public bool m_WriteBoolData;
    public int m_WriteIntData;
    public float m_WriteFloatData;
    public string m_WriteStringData;

    [Header("Read")]
    public bool m_ReadBoolData;
    public int m_ReadIntData;
    public float m_ReadFloatData;
    public string m_ReadStringData;

    [Header("DATE")]
    public InputField[] item_Date = new InputField[4];
    public Text[] Scroll_item_Date = new Text[4];

    public void WriteDate()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "/config.ini");
        if (item_Date[0].text != null && item_Date[1].text != null && item_Date[2].text != null)
        {
            WriteIni(filePath, "Section", "BoolData", item_Date[0].text.ToString());
            WriteIni(filePath, "Section", "IntData", item_Date[1].text.ToString());
            WriteIni(filePath, "Section", "FloatData", item_Date[2].text.ToString());
            WriteIni(filePath, "Section", "StringData", item_Date[3].text.ToString());
        }
    }
    public void ReadDate()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "/config.ini");

        string boolData = ReadIni(filePath, "Section", "BoolData");
        bool.TryParse(boolData, out m_ReadBoolData);

        string intData = ReadIni(filePath, "Section", "IntData");
        int.TryParse(intData, out m_ReadIntData);

        string floatData = ReadIni(filePath, "Section", "FloatData");
        float.TryParse(floatData, out m_ReadFloatData);

        string StringData = ReadIni(filePath, "Section", "StringData");        
        m_ReadStringData = StringData;

        Scroll_item_Date[0].text += "\n" + boolData;
        Scroll_item_Date[1].text += "\n" + intData;
        Scroll_item_Date[2].text += "\n" + floatData;
        Scroll_item_Date[3].text += "\n" + StringData;
    }
    public void WriteIni(string filePath, string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, filePath);
    }

    public string ReadIni(string filePath, string section, string key)
    {
        var value = new StringBuilder(255);
        GetPrivateProfileString(section, key, "Error", value, 255, filePath);
        return value.ToString();
    }
}
