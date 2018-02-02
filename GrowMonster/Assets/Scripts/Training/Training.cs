using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Training : MonoBehaviour {
    private const int Column_ = 40;
    private bool flag_ = false;
    public Player player_ = new Player();

    private int upPower = 3;
    private int upHealth = 3;
    private float upSpeed = 3;

    // Use this for initialization
    void Start () {
        //player_ = GetComponent<Player>()/*.Data*/;
        //player_.Health = GetComponent<ShinHachi.PlayerStatus>().Health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// そのうち移送するけどGUI表示関数
    /// </summary>
    public void TestGUI(bool flag)
    {
        flag_ = flag;
    }


    public void OnGUI()
    {
        if (flag_)
        {
            var group = new Vector2(150, 150);

            var screen = new Vector2(Screen.width, Screen.height);

            var groupX = (screen.x - group.x) / 2;
            var groupY = (screen.y - group.y) / 2;

            GUI.BeginGroup(new Rect(groupX, groupY, group.x, group.y));
            GUI.Box(new Rect(0, 0, group.x, group.y), "トレーニングしましょう");

            if (GUI.Button(new Rect(25, 30, 100, 30), "筋トレをする"))
            {
                player_.Power += upPower;
                Debug.Log("Power : ");
                Debug.Log(player_.Power);
                GameManager.dateBehaviour_ = true;
            }
            if (GUI.Button(new Rect(25, 30 + Column_, 100, 30), "ダッシュをする"))
            {
                player_.Speed += upSpeed;
                Debug.Log("Speed : ");
                Debug.Log(player_.Speed);
                GameManager.dateBehaviour_ = true;
            }
            if (GUI.Button(new Rect(25, 30 + Column_ * 2, 100, 30), "ランニングをする"))
            {
                player_.Health += upHealth;
                Debug.Log("Health : ");
                Debug.Log(player_.Health);
                GameManager.dateBehaviour_ = true;
            }
            GUI.EndGroup();
        }
    }


}
