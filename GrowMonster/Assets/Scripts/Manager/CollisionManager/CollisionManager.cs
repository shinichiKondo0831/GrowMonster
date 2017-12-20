using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Restaurant")
        {
            Debug.Log("レストランに入ったよ");
        }
        if(other.gameObject.name == "Training")
        {
            Debug.Log("トレーニングに入ったよ");
        }
        if(other.gameObject.name == "Item")
        {
            Debug.Log("アイテムを拾ったよ");
        }
    }
}
