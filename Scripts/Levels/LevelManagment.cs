using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  LevelManagment.Missions
{
    [Serializable]
    public class MissionSpecs
    {
        #region INSPECTOR
        [SerializeField] protected string _name;
        [SerializeField] [Multiline]protected string _discription;
        [SerializeField] protected string _sceneName;
        [SerializeField] protected string _id;
        [SerializeField] protected Sprite _image;
        #endregion

        #region PROPERITIES
        public string Name => _name;
        public string Description => _discription;
        public string SceneName => _sceneName;
        public string Id => _id;
        public Sprite Image => _image;
        #endregion



    }
}
