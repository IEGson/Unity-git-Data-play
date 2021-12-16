using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Csv_Data : MonoBehaviour
{
    //저장 데이터 형태
    public string[] m_ColumnHeadings = { "Name", "Level", "Hp" };
    public bool m_IsColumnHeading, m_IsStopWrite;
    private List<string[]> m_WriteRowData = new List<string[]>();
    //저장 위치
    public string m_Path = Application.streamingAssetsPath;
    public string m_FilePrefix = "Mouse";
    private string m_FilePath;
    private bool m_IsWriting;
    //데이터 표현
    public Text[] Scroll_item_Date = new Text[3];
    public InputField[] item_Date = new InputField[3];
    //CSV 데이터 저장하는 함수
    void Awake()
    {
        m_FilePath = m_Path + @"\" + m_FilePrefix + ".csv";
    }
    public void LoadDate()
    {
        //데이터 저장 위치 
        string[,] readDatas = ReadCsv(m_FilePath);
        //readDatas 이차 행렬의 길이는 GetLength(0) -> 1차원 길이,GetLength(1) -> 2차원 길이
        for (int i = 0; i < readDatas.GetLength(1); i++)
        {
            Scroll_item_Date[0].text += "\n" + readDatas[0, i];
            Scroll_item_Date[1].text += "\n" + readDatas[1, i];
            Scroll_item_Date[2].text += "\n" + readDatas[2, i];
        }
    }
    public void datesave()
    {
        //쓰는 상태 체크
        if (!m_IsWriting)
        {
            //컬럼 헤드를 사용할때
            if (m_IsColumnHeading)
            {
                m_WriteRowData.Add(m_ColumnHeadings);

            }
            m_IsWriting = true;
            m_IsStopWrite = true;
            StartCoroutine(CMakeRowBodys(m_ColumnHeadings.Length));
        }
        else
        {
            //쓰는중
            //Debug.Log("csv 쓰는중");
        }

    }
    // Write Csv 
    IEnumerator CMakeRowBodys(int nRows)
    {
        int interval = 1;
        while (true)
        {
            //데이터 저장하는 부분
            string[] rowDataTemp = new string[nRows];
            if (item_Date[0].text != null && item_Date[1].text != null && item_Date[2].text != null)
            {
                rowDataTemp[0] = item_Date[0].text.ToString();
                rowDataTemp[1] = item_Date[1].text.ToString();
                rowDataTemp[2] = item_Date[2].text.ToString();
            }
            else
            {
                rowDataTemp[0] = "NULL";
                rowDataTemp[1] = "NULL";
                rowDataTemp[2] = "NULL";
            }
            //행렬 데이터를 m_WriteRowData로 바뀌어주는 함수
            CsvAddRow(rowDataTemp, m_WriteRowData);      

            if (m_IsStopWrite)
            {    
                WriteCsv(m_WriteRowData, m_FilePath);
                Debug.Log(m_WriteRowData.ToString());
                m_WriteRowData.Clear();
                break;
            }

            yield return new WaitForSeconds(interval);
        }
    }

    void CsvAddRow(string[] rows, List<string[]> rowData)
    {
        string[] rowDataTemp = new string[rows.Length];
        for (int i = 0; i < rows.Length; i++)
        {
            rowDataTemp[i] = rows[i];
        }            
        rowData.Add(rowDataTemp);
    }

    public void WriteCsv(List<string[]> rowData, string filePath)
    {
        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder stringBuilder = new StringBuilder();

        for (int index = 0; index < length; index++)
            stringBuilder.AppendLine(string.Join(delimiter, output[index]));
        //FileMode.CreateNew -> 파일을 새로 생성할때 사용
        //Stream fileStream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
        //파일을 열어서 덮어쓰기 위해서 아래처럼 사용
        Stream fileStream = new FileStream(filePath, FileMode.Open , FileAccess.Write);
        StreamWriter outStream = new StreamWriter(fileStream, Encoding.UTF8);
        outStream.WriteLine(stringBuilder);
        outStream.Close();
        m_IsWriting = false;
    }

    // Read Csv 
    public string[,] ReadCsv(string filePath)
    {
        string value = "";
        StreamReader reader = new StreamReader(filePath, Encoding.UTF8);
        value = reader.ReadToEnd();
        reader.Close();

        string[] lines = value.Split("\n"[0]);

        int width = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] row = SplitCsvLine(lines[i]);
            width = Mathf.Max(width, row.Length);
        }

        string[,] outputGrid = new string[width + 1, lines.Length + 1];
        for (int y = 0; y < lines.Length; y++)
        {
            string[] row = SplitCsvLine(lines[y]);
            for (int x = 0; x < row.Length; x++)
            {
                outputGrid[x, y] = row[x];
                outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
            }
        }

        return outputGrid;
    }
    //CSV 행분할
    public string[] SplitCsvLine(string line)
    {
        return (from Match m in System.Text.RegularExpressions.Regex.Matches(line,
        @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
        RegexOptions.ExplicitCapture)
                select m.Groups[1].Value).ToArray();
    }
}
