using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager1 : MonoBehaviour {

    private bool flag_ = false;

    private BattleState currentState_;

    public Player player_ = new Player();

    public Player enemy_ = new Player();

    public float[] resultSpeed_ = new float[2];

    public enum BattleState
    {
        START,
        PREPARE,
        BATTLE
    }


    public void SetCurrentState(BattleState state)
    {
        currentState_ = state;
        OnGameStateChanged(currentState_);
    }

    // Use this for initialization
    void Awake () {
        flag_ = false;
        OnGameStateChanged(BattleState.START);
	}
    void OnGameStateChanged(BattleState state)
    {
        switch (state)
        {
            case BattleState.START:
                SetCurrentState(BattleState.PREPARE);
                break;

            case BattleState.PREPARE:
                //StartCoroutine(PrepareCoroutine(timeCount_));
                PrepareCoroutine();
                break;

            case BattleState.BATTLE:
                Battle();
                break;

            default:
                break;
        }
    }

    public void PrepareCoroutine()
    {
        SetCurrentState(BattleState.BATTLE);
    }

    public void Battle()
    {
        flag_ = true;
        resultSpeed_[0] = (player_.Health + player_.Speed + player_.Power) / 3;
        resultSpeed_[1] = (enemy_.Health + enemy_.Speed + enemy_.Power) / 3;
    }
    

    // Update is called once per frame
    void Update () {
		if(flag_)
        {
            resultSpeed_[0] = (player_.Health + player_.Speed + player_.Power) / 3 * Random.Range(1, 3);
            resultSpeed_[1] = (enemy_.Health + enemy_.Speed + enemy_.Power) / 3 * Random.Range(1,3);
            player_.transform.position += transform.forward * resultSpeed_[0] * Time.deltaTime;
            enemy_.transform.position += transform.forward * resultSpeed_[1] * Time.deltaTime;
            //player_.transform.position += transform.forward * player_.Speed * Time.deltaTime;
            //enemy_.transform.position += transform.forward * enemy_.Speed * Time.deltaTime;
        }
	}
}
