using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private ShinHachi.PlayerStatus playerInfo_ = new ShinHachi.PlayerStatus();
    private GameObject obj_;
    //private Player player_ = new Player();
	// Use this for initialization
	void Start () {
        obj_ = GameObject.Find("Slime_Green");
        playerInfo_ = GetComponent<PlayerInfo>().Data;
	}
	
	// Update is called once per frame
	void Update () {
       
	}


    // アクセッサ

    public ShinHachi.PlayerStatus Data
    {
        get { return playerInfo_; }
        set
        {
            playerInfo_ = value;
        }
    }


    public int Health
    {
        get { return playerInfo_.Health; }
        set
        {
            playerInfo_.Health = value;
        }
    }

    public float Speed
    {
        get { return playerInfo_.Speed; }
        set
        {
            playerInfo_.Speed = value;
        }
    }

    public int Power
    {
        get { return playerInfo_.Power; }
        set
        {
            playerInfo_.Power = value;
        }
    }
}
