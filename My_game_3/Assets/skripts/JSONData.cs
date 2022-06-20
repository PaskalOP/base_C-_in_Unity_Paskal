using System.Xml.Serialization;
using UnityEngine;
using System.IO;

namespace Maze
{
    public class JSONData: ISaveData
    {
        string SavePath = Path.Combine(Application.dataPath, "JSONDataPlayer.json");
       

        public void SaveData(PlayerData _player)
        {
            string FileJSON = JsonUtility.ToJson(_player);
            File.WriteAllText(SavePath, FileJSON);
        }
        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("Фаил не найден");
                return result; 
            }

            string tempJson = File.ReadAllText(SavePath);
            result = JsonUtility.FromJson<PlayerData>(tempJson);
            return result;

        }
    }
}

