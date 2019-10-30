using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Computer : MonoBehaviour
    {

        public bool isOn;

        public Color buttonEnable;
        public Color buttonDisable;

        private Dictionary<string, GameObject> screens = new Dictionary<string, GameObject>();
        public GameObject[] screenList;

        private GameObject currentScreen;

        private void Start()
        {
            foreach(GameObject g in screenList)
            {
                screens.Add(g.name, g);
            }

            ChangeScreen("Desktop");

        }

        private void Update()
        {
            transform.GetChild(0).gameObject.SetActive(isOn);
        }

        public GameObject GetScreen(string screenName)
        {
            return screens[screenName];
        }

        public void ChangeScreen(string screenName)
        {
            var newScreen = screens[screenName];
            if (currentScreen != null)
                currentScreen.SetActive(false);

            newScreen.SetActive(true);
            currentScreen = newScreen;
        }

    }
}
