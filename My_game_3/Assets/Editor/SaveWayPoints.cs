using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml.Serialization;


namespace Maze
{
    [CustomEditor(typeof(WayPoints))]
    public class SaveWayPoints : Editor
    {
        private static XmlSerializer _serializer;
        public List<SVect3> SavingNods = new List<SVect3>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            WayPoints Base = (WayPoints)target;
            if (_serializer ==null)
            {
                _serializer = new XmlSerializer(typeof(SVect3[]));
            }
            if (GUILayout.Button("Сохранить"))
            {
                if (Base.nodes.Count > 0)
                {
                    foreach (Transform  item in Base.nodes)
                    {
                        if (!SavingNods.Contains(item.position))
                            SavingNods.Add(item.position);
                    }
                }
                using (FileStream fs = new FileStream(Base.SavingPath, FileMode.Create))
                {
                    _serializer.Serialize(fs, SavingNods.ToArray()); 
                }
            }
           
        }
    }
}

