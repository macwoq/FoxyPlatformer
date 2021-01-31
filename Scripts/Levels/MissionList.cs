using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagment.Missions
{
    [CreateAssetMenu(fileName = "MissionList", menuName = "Missions/Create MissionList", order = 1)]

    public class MissionList : ScriptableObject
    {
        #region INSPECTOR
        [SerializeField] private List<MissionSpecs> _missions;
        #endregion

        #region PROPERITIES
        public int TotalMissions => _missions.Count;
        #endregion 

        public MissionSpecs  GetMission(int index)
        {
            return _missions[index];
        }
    }
}
