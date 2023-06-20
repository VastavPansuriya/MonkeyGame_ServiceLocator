using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator.Map
{
    [CreateAssetMenu(fileName = "MapScriptableObject", menuName = "ScriptableObjects/MapScriptableObject")]
    public class MapScriptableObject : ScriptableObject
    {
        public List<MapData> MapDataByLevels;
    }

    [System.Serializable]
    public struct MapData
    {
        public int MapID;
        public Vector3 SpawningPoint;
        public List<Vector3> WayPoints;
    }
}