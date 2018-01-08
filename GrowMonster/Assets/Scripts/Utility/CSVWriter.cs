using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class CSVWriter : MonoBehaviour
{
    public void CSVWritting(int times, int value)
    {
        StreamWriter sw;
        FileInfo fi;
        fi = new FileInfo(Application.dataPath + "/FileName.csv");
        sw = fi.AppendText();
        for(int i = 0; i < times;i++)
        {
            sw.WriteLine(value);
        }
        sw.Flush();
        sw.Close();
    }
}