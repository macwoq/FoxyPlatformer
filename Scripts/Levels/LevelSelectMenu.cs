using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagment.Missions;

namespace LevelManagment
{
    [RequireComponent(typeof(MissionSelector))]
    public class LevelSelectMenu 
    {
        [SerializeField] protected Text _nameText;
        [SerializeField] protected Text _discriptionText;
        [SerializeField] protected Image _previewImage;

        protected MissionSelector _missionSelector;
        protected MissionSpecs _currentMission;
        
        


    }
}
