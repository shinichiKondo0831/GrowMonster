using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerInfoのスクリプトを一緒にアタッチできるようにする
[RequireComponent(typeof(PlayerInfo))]
public class PlayerController : MonoBehaviour
{
    Player player_ = new Player();

    // Use this for initialization
    void Start ()
    {
        player_ = GetComponent<Player>();
    }
  
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * player_.Speed * Time.deltaTime;
            //Debug.Log("移動スピード : ");
            //Debug.Log(player_.Speed);
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * player_.Speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * player_.Speed * Time.deltaTime;
        }

        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * player_.Speed * Time.deltaTime;
        }

    }

    public Player DataP
    {
        get { return player_; }
    }
}
