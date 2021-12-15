using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Canvas(= ui) 사용하기 위한 선언

public class PlayPrefs_data : MonoBehaviour
{
    [SerializeField]
    InputField input; // string
    [SerializeField]
     Slider silde; // float
    public Text input_text, silde_text;
    //PlayerPrefs 저장 경로
    // 레지스트리 편집기 -> HKEY_CURRENT_USER\SOFTWARE\Unity\회사이름\프로젝트명

    //데이터저장
    public void Save()
    {
        PlayerPrefs.SetString("StringA", input.text);
        PlayerPrefs.SetFloat("SilderA", silde.value);
    }
    //데이터 불러오기
    public void Load()
    {
        input_text.text = PlayerPrefs.GetString("StringA");
        silde_text.text = PlayerPrefs.GetFloat("SilderA").ToString();
    }
}
