using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//serizlized 저장방식(파일)
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Binartfiled : MonoBehaviour
{    
    public static float ftime; // 일반 변수A
    public static int uselevel = 0; // 일반 변수A
    public Text Date; //ui에 텍스트
    public InputField Date_input; //저장할 입력필드

    [Serializable] // 직렬화한 변수 선언 B
    public class Playerdata
    {
        public float ftime;
        public int uselevel;
    }

    void Update()
    {       
        ftime += Time.deltaTime;
    }
    //데이터 저장
    public void Savedata() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Resources/playerinfo.dat"); //FileStream은 파일 시스템에서 파일을 읽고, 쓰고, 열고, 닫고 표준 입력 및 표준 출력을 포함한 다른 파일 관련 운영 체제 핸들을 조작 
        //Application.dataPath 파일 저장 경로는 유니티 - Assets에 저장
        //Application.persistentDataPath 파일 저장 경로는  C:\Users\사용자이름\AppData\LocalLow\회사이름
        Playerdata data = new Playerdata();
        // a->b에 할당
        if (Date_input.text != null)
        {
            data.uselevel = int.Parse(Date_input.text.ToString());
        }
        data.ftime = ftime;
        // b->file에 할당
        bf.Serialize(file, data);
        file.Close();
    }
    //데이터 불러오기
    public void LoadData() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/Resources/playerinfo.dat", FileMode.Open);
        if (file != null && file.Length > 0)
        {
            // 파일에서 역직렬화해서 b에 담는다
            Playerdata data = (Playerdata)bf.Deserialize(file);
            // b -> a에 할당
            uselevel = data.uselevel;
            ftime = data.ftime;
            Date.text = uselevel.ToString();
        }
        file.Close();
        }
}

