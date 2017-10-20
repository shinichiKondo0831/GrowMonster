using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShinHachi
{
    [CreateAssetMenu(menuName = "PlayerData/Create PlayerDataAsset Instance")]
    public class PlayerData : ScriptableObject
    {

        [SerializeField]
        List<PlayerDataList> _list = new List<PlayerDataList>();

        public PlayerDataList GetData(int id)
        {
            if (_list.Count < id || id >= 0)
            {
                return _list[id];
            }

            return null;
        }

        public int GetLength()
        {
            return _list.Count;
        }

        [System.SerializableAttribute]
        public class PlayerDataList
        {
            public int Hp;
            public int AttackPowerBias;
            public float MoveSpeed;
        }
    }
}