using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    // 何日過ごしたかをカウントする変数
    private int dateCount_ = 0;
    [SerializeField]
    private int timeCount_ = 0;

    private GameState currentState_;

    GameObject sun;


    public enum GameState
    {
        START,
        PREPARE,
        GROWING
    }

    public enum TimeState
    {
        A_M,
        DAYTIME,
        P_M
    }


    void Awake()
    {
        sun = GameObject.Find("Directional Light");
        SetCurrentState(GameState.START);
    }


    public void SetCurrentState(GameState state)
    {
        currentState_ = state;
        OnGameStateChanged(currentState_);
    }

    void OnGameStateChanged(GameState state)
    {
        if (dateCount_ != 4)
        {
            switch (state)
            {
                case GameState.START:
                    SetCurrentState(GameState.PREPARE);
                    break;

                case GameState.PREPARE:
                    StartCoroutine(PrepareCoroutine(timeCount_));
                    break;

                case GameState.GROWING:
                    GrowingAction();
                    break;

                default:
                    break;
            }
        }
        else
        {
            Debug.Log("バトル開始まで遷移する");
        }
    }

    IEnumerator PrepareCoroutine(int time)
    {
        Debug.Log("時間帯によってのアニメーション開始");
        StartCoroutine(TimeAnimation(time));
        SetCurrentState(GameState.GROWING);
        yield break;
    }

    IEnumerator TimeAnimation(int time_)
    {
        if(time_ == (int)TimeState.A_M)
        {
            sun.transform.rotation = transform.rotation * Quaternion.Euler(Vector3.Lerp(Vector3.zero,new Vector3(50.0f,0.0f,0.0f),10.0f));
            Debug.Log("朝");
        } else if(time_ == (int)TimeState.DAYTIME)
        {
            sun.transform.rotation = transform.rotation * Quaternion.Euler(Vector3.Lerp(Vector3.zero, new Vector3(150.0f, 0.0f, 0.0f), 10.0f));
            Debug.Log("昼");
        } else if(time_ == (int)TimeState.P_M)
        {
            sun.transform.rotation = transform.rotation * Quaternion.Euler(Vector3.Lerp(Vector3.zero, new Vector3(280.0f, 0.0f, 0.0f), 10.0f));
            Debug.Log("夜");
        }
        yield return new WaitForSeconds(10);

    }

    void GrowingAction()
    {
        Debug.Log("育ててます");
    }

    void Update()
    {
        if (currentState_ == GameState.GROWING)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                timeCount_++;
                dateCount_++;
                OnGameStateChanged(GameState.START);
            }
        }
    }
}
