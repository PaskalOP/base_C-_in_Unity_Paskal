
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


//#if UNITY_EDITOR

namespace Maze
{


    public class WayPoints : MonoBehaviour
    {
        public List<Transform> nodes = new List<Transform>();
        
        public string directoryName;
        private string savingPath;
        public string SceneName;

        public string SavingPath {get => savingPath; set => savingPath= value;}
        private void Awake()
        {
            OnDrawGizmos();
        }

        private void OnDrawGizmos()
        {
            SceneName = SceneManager.GetActiveScene().name;
            directoryName = "Bonus Data";
            SavingPath = Path.Combine((Application.dataPath + "/" +  directoryName), "Bonus Map" + SceneName + ".xml");
        }    
     }

}

//#endif
