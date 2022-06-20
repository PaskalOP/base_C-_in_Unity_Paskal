using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace Maze
{
    public class JSONBonus
    {
        string SaveBonus = Path.Combine(Application.dataPath, "JSONDataBonus.json");
        public void SaveDataB(SObject _bonus)
        {
            string FileJSON = JsonUtility.ToJson(_bonus);
            File.WriteAllText(SaveBonus, FileJSON);
        }
        public SObject LoadB()
        {
            SObject result = new SObject();
            if (!File.Exists(SaveBonus))
            {
                Debug.Log("Фаил не найден");
                return result;
            }

            string tempJson = File.ReadAllText(SaveBonus);
            result = JsonUtility.FromJson<SObject>(tempJson);
            return result;

        }
    }
}

