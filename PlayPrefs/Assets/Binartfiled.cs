using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//serizlized 저장방식(파일)
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Binartfiled : MonoBehaviour
{
    /*
    public static float ftime; // 일반 변수A
    public static int uselevel = 0; // 일반 변수A

    [Serializable] // 직렬화한 변수 선언 B
    public class Playerdata
    {
        public int uselevel;
        public float ftime;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9)) // 데이터를 읽어온다
        {
            LoadData();
        }
        if (Input.GetKeyDown(KeyCode.F10)) // 데이터를 저장한다
        {
            Savedata();
        }
        if (Input.GetKeyDown(KeyCode.F11)) // 변수값 증가 -> 저장은 안된다 저장하기 위해서는 F10을 눌러야한다.
        {
            uselevel++;
        }
        ftime += Time.deltaTime;
    }
    public void Savedata() // 1.게임 데이터 일반 변수 선언, 값 할당 2.Serializable 클래스 선언 3.FileStream 클래스 이용 파일 생성(f) 4.  a->b에 할당 5.b->f에 할당
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/playerinfo.dat"); //FileStream은 파일 시스템에서 파일을 읽고, 쓰고, 열고, 닫고 표준 입력 및 표준 출력을 포함한 다른 파일 관련 운영 체제 핸들을 조작 
        //Application.dataPath 파일 저장 경로는 유니티 - Assets에 저장
        //Application.persistentDataPath 파일 저장 경로는  C:\Users\사용자이름\AppData\LocalLow\회사이름
        Playerdata data = new Playerdata();
        // a->b에 할당
        data.uselevel = uselevel;
        data.ftime = ftime;
        // b->file에 할당
        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadData() // 1.게임 데이터 일반 변수 선언, 값 할당 2.Serializable 클래스 선언 3.FileStream 클래스 이용 파일 생성(f) 4.  a->b에 할당 5.b->f에 할당
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/playerinfo.dat", FileMode.Open);
        if (file != null && file.Length > 0)
        {
            // 파일에서 역직렬화해서 b에 담는다
            Playerdata data = (Playerdata)bf.Deserialize(file);
            // b -> a에 할당
            uselevel = data.uselevel;
            ftime = data.ftime;
            Debug.Log(uselevel);
            Debug.Log(file);
        }
        file.Close();
        }*/
}

