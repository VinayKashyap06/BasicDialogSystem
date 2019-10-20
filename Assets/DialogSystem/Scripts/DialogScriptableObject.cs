using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    
    [CreateAssetMenu(fileName ="Dialog Settings",menuName ="Custom Objects/Dialog Settings",order =0)]
    public class DialogScriptableObject : ScriptableObject
    {
        public List<DialogData> dialogData;
    }
}