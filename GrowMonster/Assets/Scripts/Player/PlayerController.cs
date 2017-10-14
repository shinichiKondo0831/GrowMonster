using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // プレイヤーの内部データ
    ShinHachi.PlayerStatus _data = null;
    public ShinHachi.PlayerStatus PlayerData
    {
        get { return _data; }
    }


	// Use this for initialization
	void Start () {

        _data = new ShinHachi.PlayerStatus();
        ShinHachi.PlayerData.PlayerDataList data = null;

        _data.MaxHealth = data.Hp;
        _data.Health    = _data.Health;
        _data.Power     = data.AttackPowerBias;
        _data.Velocity = data.MoveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
