using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] List<GameObject> dialogs;
        AudioManager _audioManager;
        
        public Action onDialogFinish;
        void OnEnable()
        {
            onDialogFinish += CleanDialogs;
            _audioManager = FindObjectOfType<AudioManager>();
            StartCoroutine(StartDialog());
        }

        void CleanDialogs()
        {
            foreach (var dialog in dialogs)
            {
                dialog.SetActive(false);
            }
        }

        IEnumerator StartDialog()
        {
            var count = 0;
            while (true)
            {
                buildNextDialog(count);
                count++;

                if (count == 2)
                {
                    yield return new WaitForSeconds(2f);
                }
                else if (count == 6)
                {
                    yield return new WaitForSeconds(12f);
                }
                else
                {
                    yield return new WaitForSeconds(4f);
                }
                
                
                if (count >= dialogs.Count){
                    onDialogFinish.Invoke();
                    yield break;
                }
                
                

            }
        }

        void buildNextDialog(int count)
        {
            if (count >= 1)
            {
                dialogs[count - 1].gameObject.SetActive(false);
            }

            if (count <= dialogs.Count)
            {
                dialogs[count].gameObject.SetActive(true);
                _audioManager.Play("dialogo");
            }
        }
    }
}