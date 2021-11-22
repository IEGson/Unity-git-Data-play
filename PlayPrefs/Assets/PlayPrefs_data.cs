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
    public void Save()
    {
        PlayerPrefs.SetString("StringA", input.text);
        PlayerPrefs.SetFloat("SilderA", silde.value);
    }
    // Start is called before the first frame update
    public void Load()
    {
        input.text = PlayerPrefs.GetString("StringA");
        silde.value = PlayerPrefs.GetFloat("SilderA");
    }
}
