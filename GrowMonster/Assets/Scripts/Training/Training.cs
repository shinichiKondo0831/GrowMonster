using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour {
    private const int Column_ = 40;
    private bool flag_ = false;
    // Use this for initialization
    void Start () {

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
            var group = new Vector2(120, 250);

            var screen = new Vector2(Screen.width, Screen.height);

            var groupX = (screen.x - group.x) / 2;
            var groupY = (screen.y - group.y) / 2;

            GUI.BeginGroup(new Rect(groupX, groupY, group.x, group.y));
            GUI.Box(new Rect(0, 0, group.x, group.y), "トレーニングしましょう");

            if (GUI.Button(new Rect(10, 30, 100, 30), "筋力を上げる"))
            {
                GameManager.dateBehaviour_ = true;
            }
            if (GUI.Button(new Rect(10, 30 + Column_, 100, 30), "筋力を上げる"))
            {

            }
            if (GUI.Button(new Rect(10, (30 + Column_) * 2, 100, 30), "筋力を上げる"))
            {

            }
            GUI.EndGroup();
        }
    }


}
