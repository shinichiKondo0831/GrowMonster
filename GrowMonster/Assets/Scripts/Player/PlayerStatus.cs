using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShinHachi
{
    public class PlayerStatus {

        /// <summary>
        /// プレイヤー内部データ
        /// </summary>
        public class Data
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="velocity">スピード</param>
            /// <param name="power">攻撃力</param>
            /// <param name="health">HP</param>
            public Data(float velocity, int power, int health, int maxHealth)
            {
                this._health = health;
                this._power = power;
                this._speed = velocity;
                this._maxHealth = maxHealth;
            }

            //-------プロパティ内部変数-----------------//
            // プレイヤーの速度
            public float _speed = 0.0f;

            // プレイヤーの力
            public int _power = 0;

            // プレイヤーのHp
            public int _health = 0;

            // プレイヤーの最大Hp
            public int _maxHealth = 0;

            
        }

        //------------------------------------------//
        //-------プロパティ設定---------------------//
        //------------------------------------------//
        //-------使用例-----------------------------//
        //------------------------------------------//
        //-------変数名 = 変数名.プロパティ名-------//
        //------------------------------------------//

        Data _data = new Data(0f, 0, 0, 0);
        //------*ゲッター&セッター*------//

        /// <summary>
        /// プレイヤーのデータを返す
        /// </summary>
        public Data PublicPlayerData
        {
            get { return _data; }
        }


        /// <summary>
        /// スピード
        /// </summary>
        public float Speed
        {
            get { return _data._speed; }
            set
            {
                _data._speed = value;
            }
        }

        /// <summary>
        /// HP
        /// </summary>
        public int Health
        {
            get { return _data._health; }
            set
            {
                _data._health = value;
            }
        }

        /// <summary>
        /// 攻撃力
        /// </summary>
        public int Power
        {
            get { return _data._power; }
            set
            {
                _data._power = value;
            }
        }

        /// <summary>
        /// 最大HP
        /// </summary>
        public int MaxHealth
        {
            get { return _data._maxHealth; }
            set
            {
                _data._maxHealth = value;
            }
        }

    }
}

