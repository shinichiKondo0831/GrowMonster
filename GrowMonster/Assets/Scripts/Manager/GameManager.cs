using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    [SerializeField]
    // 何日過ごしたかをカウントする変数
    private int dateCount_ = 0;
    [SerializeField]
    private int timeCount_ = 0;

    public static bool dateBehaviour_ = false;

    public Player player_ = new Player();

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
                    dateBehaviour_ = false;
                    SetCurrentState(GameState.PREPARE);
                    break;

                case GameState.PREPARE:
                    //StartCoroutine(PrepareCoroutine(timeCount_));
                    PrepareCoroutine(timeCount_);
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
            float[] playerArray = new float[3];
            playerArray[0] = player_.Health;
            playerArray[1] = player_.Speed;
            playerArray[2] = player_.Power;
            CSVWriter write = new CSVWriter();
            write.CSVWritting(3, playerArray);
            SceneManager.LoadScene("Battle");
        }
    }

    public void PrepareCoroutine(int time)
    {
        Debug.Log("時間帯によってのアニメーション開始");
        TimeAnimation(time);
        SetCurrentState(GameState.GROWING);
    }

    public void TimeAnimation(int time_)
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

    }

    void GrowingAction()
    {
        Debug.Log("育ててます");
        // ここに育成スタートイベントを発生させる(もしくは普通に関数)
    }

    void Update()
    {
        if (dateCount_ <= 3)
        {
            if (currentState_ == GameState.GROWING)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    timeCount_++;
                    if (timeCount_ > (int)TimeState.P_M)
                    {
                        dateCount_++;
                        timeCount_ = 0;
                    }
                    OnGameStateChanged(GameState.START);
                }
                if (dateBehaviour_)
                {
                    timeCount_++;
                    if (timeCount_ > (int)TimeState.P_M)
                    {
                        dateCount_++;
                        timeCount_ = 0;
                    }
                    OnGameStateChanged(GameState.START);
                }
            }
        }
    }
}
