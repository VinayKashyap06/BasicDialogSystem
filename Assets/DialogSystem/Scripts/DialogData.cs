using System;
using UnityEngine;

namespace DialogSystem
{
    public enum e_Actor
    {
        NONE,
        LEFT,
        RIGHT
    }
    [Serializable]
    public class DialogData
    {
        public string name;
        public string dialog;
        public e_Actor actor;
        public AudioClip audioClip;
        public Sprite characterImage;       
    }
}
