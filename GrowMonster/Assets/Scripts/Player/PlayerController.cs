using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public string csvName_ = null; 
    // csv読み込み行ったデータ格納コンテナ
    private List<string[]> csvData_ = new List<string[]>();
    // プレイヤーの内部データ
    ShinHachi.PlayerStatus data_ = new ShinHachi.PlayerStatus();

    enum STATUS
    {
        HELTH,
        SPEED,
        POWER
    };

	// Use this for initialization
	void Start () {
        StartCoroutine("CharacterData");
        Debug.Log("内部データ");
        Debug.Log(data_.Health);
        Debug.Log(data_.Velocity);
        Debug.Log(data_.Power);
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
        data_.Velocity = int.Parse(csv_.OutputData()[0][(int)STATUS.SPEED]);
        data_.Power = int.Parse(csv_.OutputData()[0][(int)STATUS.POWER]);
        yield return data_;
        
    }
  
}
