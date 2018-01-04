using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterEvent : MonoBehaviour {

    public delegate void playerCollision();
    private playerCollision _playerCollision;

    /// <summary>
    /// 当たり判定をとった場合のイベントをセットする
    /// </summary>
    /// <param name="_playerCollision"></param>
    public void SetPlayerCollision(playerCollision _playerCollision)
    {
        this._playerCollision = _playerCollision;
    }

    /// <summary>
    /// 当たり判定をとった場合のイベントを追加する
    /// </summary>
    /// <param name="_playerCollision"></param>
    public void AddPlayerCollision(playerCollision _playerCollision)
    {
        this._playerCollision += _playerCollision;
    }

    /// <summary>
    /// 当たり判定をとった場合のイベントを実行する
    /// </summary>
    public void ExecutionPlayerCollision()
    {
        this._playerCollision();
    }

}
