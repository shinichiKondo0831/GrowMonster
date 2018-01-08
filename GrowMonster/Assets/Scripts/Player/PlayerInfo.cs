using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    [SerializeField]
    public string csvName_ = null;
    // csv読み込み行ったデータ格納コンテナ
    private List<string[]> csvData_ = new List<string[]>();
    // プレイヤーの内部データ
    public ShinHachi.PlayerStatus data_ = new ShinHachi.PlayerStatus();

    CSVWriter write/* = new CSVWriter()*/;
    public ShinHachi.PlayerStatus Data
    {
        get { return data_;}
    }

    enum STATUS
    {
        HELTH,
        SPEED,
        POWER
    };

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CharacterData());
    }

    /// <summary>
    /// Characterのデータを読み取るまで次の処理を行わない
    /// </summary>
    /// <returns></returns>
    private IEnumerator CharacterData()
    {
        CSVReader csv_ = new CSVReader();
        csv_.CsvRead(csvName_);
        data_.Health = int.Parse(csv_.OutputData()[0][(int)STATUS.HELTH]);
        data_.Speed = int.Parse(csv_.OutputData()[0][(int)STATUS.SPEED]);
        data_.Power = int.Parse(csv_.OutputData()[0][(int)STATUS.POWER]);
        //.write = GetComponent<CSVWriter>();
        write.CSVWritting(3,5);
        yield break;
    }

    void Update()
    {

    }

}
