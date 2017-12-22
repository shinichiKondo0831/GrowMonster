using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterEvent : MonoBehaviour {
    
    public delegate void playerCollision();
    private playerCollision _playerCollision;

    public void SetPlayerCollision(playerCollision _playerCollision)
    {
        this._playerCollision = _playerCollision;
    }

    public void AddPlayerCollision(playerCollision _playerCollision)
    {
        this._playerCollision += _playerCollision;
    }

    public void ExecutionPlayerCollision()
    {
        this._playerCollision();
    }
}
