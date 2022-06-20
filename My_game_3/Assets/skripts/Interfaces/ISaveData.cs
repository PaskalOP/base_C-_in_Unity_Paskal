using System.Collections;
using UnityEngine;

namespace Maze
{
    public interface ISaveData
    {
        void SaveData(PlayerData _player);
        PlayerData Load();
    }
}

