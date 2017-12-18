using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerInfoのスクリプトを一緒にアタッチできるようにする
[RequireComponent(typeof(PlayerInfo))]
public class PlayerController : MonoBehaviour
{
    ShinHachi.PlayerStatus data_ = new ShinHachi.PlayerStatus();

    // Use this for initialization
    void Start ()
    {
        data_ = GetComponent<PlayerInfo>().Data;
    }
  
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * data_.Speed * Time.deltaTime;
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * data_.Speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * data_.Speed * Time.deltaTime;
        }

        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * data_.Speed * Time.deltaTime;
        }

    }
}
