using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    public CharcterEvent collisionEvent_;
    public Training training_ = new Training();
    private bool flag_ = false;

    void Start() {
        collisionEvent_ = new CharcterEvent();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Restaurant")
        {
            Debug.Log("レストランに入ったよ");
        }
        if(other.gameObject.name == "Training")
        {
            Debug.Log("トレーニングに入ったよ");
            flag_ = true;
            collisionEvent_.SetPlayerCollision(InvisibleGUI);
            collisionEvent_.ExecutionPlayerCollision();
        }
        if(other.gameObject.name == "Item")
        {
            Debug.Log("アイテムを拾ったよ");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Training")
        {
            Debug.Log("トレーニングに入ったよ");
            flag_ = false;
            collisionEvent_.SetPlayerCollision(InvisibleGUI);
            collisionEvent_.ExecutionPlayerCollision();
        }
    }

    private void InvisibleGUI()
    {
        training_.TestGUI(flag_);
    }


}
