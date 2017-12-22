using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    public CharcterEvent collisionEvent_;
    public Training training_ = new Training();

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
            collisionEvent_.SetPlayerCollision(InvisibleGUI);
            collisionEvent_.ExecutionPlayerCollision();
        }
        if(other.gameObject.name == "Item")
        {
            Debug.Log("アイテムを拾ったよ");
        }
    }

    private void InvisibleGUI()
    {
        training_.TestGUI();
    }


}
