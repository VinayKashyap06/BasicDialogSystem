using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using SoundSystem;
using UnityEngine.Timeline;
using System;

namespace DialogSystem
{
    public class DialogController : MonoBehaviour
    {
        #region PrivateVariables
        [SerializeField] private TextMeshProUGUI dialog;
        [SerializeField] private Image actor1;
        [SerializeField] private Image actor2;
        [SerializeField] private Button skipButton;
        [SerializeField] private PlayableDirector director;
        [SerializeField] private DialogScriptableObject dialogSettings;

        private List<DialogData> dialogData = new List<DialogData>();
        private bool skipPressed=false;
        private int activeDialogIndex;
        private float waitTime=0f;
        private Image currentActor;
        private Image previousActor;
        #endregion

        private void Start()
        {
            dialogData = dialogSettings.dialogData;
            skipButton.onClick.AddListener(Toggleskip);
            currentActor = actor1;
            previousActor = actor1;
            Coroutine coRou=StartCoroutine(FetchDialog());
        }

        private void Toggleskip()
        {
            skipPressed = true;
            ServiceSound.Instance.StopCurrentClip();
            waitTime = 0;
            skipPressed = false;
        }

        IEnumerator FetchDialog()
        {

            for (int i = 0; i < dialogData.Count; i++)
            {                
                previousActor = currentActor;
                currentActor = dialogData[i].actor == e_Actor.LEFT ? actor1 : actor2;

                previousActor.color = Color.gray;
                currentActor.color = Color.white;

                dialog.text = dialogData[i].dialog;
                if (dialogData[i].audioClip!=null)
                {
                    ServiceSound.Instance.PlayClip( dialogData[i].audioClip);
                    waitTime = dialogData[i].audioClip.length;
                    Debug.Log(waitTime);
                }

                yield return new WaitForEndOfFrame();
                yield return new WaitForSeconds(waitTime);
            }
        }        
    }
}