using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wreckless
{
    public class ScreenMessageSystem : MonoBehaviour
    {

        public static ScreenMessageSystem Instance;


        public float messageTime = 3f;
        public TextMeshProUGUI messageTxt;

        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            messageTxt.gameObject.SetActive(false);
        }

        public void ShowMessage(string message)
        {
            StartCoroutine("ShowMessageTimer", message);
        }

        private IEnumerator ShowMessageTimer(string message)
        {
            messageTxt.gameObject.SetActive(true);
            messageTxt.text = message;
            yield return new WaitForSeconds(messageTime);
            messageTxt.gameObject.SetActive(false);

        }


    }
}
