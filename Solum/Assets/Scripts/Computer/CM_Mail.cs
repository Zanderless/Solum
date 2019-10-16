using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Wreckless
{
    [AddComponentMenu("Computer/CM_Mail")]
    public class CM_Mail : ComputerModule
    {
        
        [TextArea(1, 5)]
        public string mailContent;

        public GameObject mailScreen;

        public override void DoModule()
        {
            Initilize();
            mailScreen.SetActive(true);
        }

        private void Initilize()
        {
            Button backBtn = FindType<Button>();
            TextMeshProUGUI mailTxt = FindType<TextMeshProUGUI>();

            mailTxt.text = mailContent;

            backBtn.onClick.AddListener(BackClick);
            
        }

        private void BackClick()
        {
            mailScreen.SetActive(false);
        }

        private T FindType<T>()
        {
            for(int i = 0; i < mailScreen.transform.childCount; i++)
            {
                if (mailScreen.transform.GetChild(i).GetComponent<T>() != null)
                    return mailScreen.transform.GetChild(i).GetComponent<T>();
            }

            return default;

        }

    }
}
