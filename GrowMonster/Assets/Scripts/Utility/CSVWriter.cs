using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class CSVWriter : MonoBehaviour
{
    public void CSVWritting(int times, float[] value)
    {
        StreamWriter sw;
        FileInfo fi;
        fi = new FileInfo(Application.dataPath+ "/Resources" + "/CSV"+ "/Grow.csv");
        sw = fi.AppendText();
        sw.WriteLine("読み飛ばし");
        for(int i = 0; i < times;i++)
        {
            sw.Write((int)value[i]);
            if(i < times - 1)
            sw.Write(",");
        }
        sw.Flush();
        sw.Close();
    }
}