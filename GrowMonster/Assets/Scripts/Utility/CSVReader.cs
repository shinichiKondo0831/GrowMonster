using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour {

    private List<string[]> csvData_ = new List<string[]>();

    private int count;

    /// <summary>
    /// CSV読み込み
    /// </summary>
    /// <param name="csvName"></param>
    public void CsvRead(string csvName)
    {
        TextAsset csv_ = Resources.Load("CSV/" + csvName) as TextAsset;
        StringReader reader_ = new StringReader(csv_.text);

        reader_.ReadLine(); // 1行読み捨てる。
        while (reader_.Peek() != -1)
        {
            string line_ = reader_.ReadLine();
            csvData_.Add(line_.Split(','));
            count++;
        }
    }

    
    public List<string[]> OutputData()
    {
        return csvData_;
    }
}
