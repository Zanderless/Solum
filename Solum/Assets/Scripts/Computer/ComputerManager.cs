using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Wreckless
{
    public class ComputerManager : MonoBehaviour
    {

        public static ComputerManager local;
        private Computer activeComputer;
        private Computer _lastActiveComputer;

        public GameObject passCodeScreen;
        public GameObject computerScreen;

        public GameObject moduleButtonPrefab;
        public TMP_InputField passcodeField;

        public GameObject[] moduleScreens;

        public GameObject desktopScreen;

        private void Awake()
        {
            local = this;
        }

        //Set the active computer being used
        public void SetActiveComputer(Computer comp)
        {
            activeComputer = comp;
        }

        public void SetPassCodeText(string text)
        {
            activeComputer.SetPassCodeText(text);
        }

        //Checks to see if the passcode connected to the active computer is the same as the one typed in
        public void CheckPasscode()
        {
            activeComputer.CheckPasscode();
        }

        private void Update()
        {
            passCodeScreen.SetActive(activeComputer != null && activeComputer.needsPasscode && activeComputer.onComputer);
            computerScreen.SetActive(activeComputer != null && !activeComputer.needsPasscode && activeComputer.onComputer);

            Cursor.visible = activeComputer != null && activeComputer.onComputer;

            if (Cursor.visible)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }

        //Are we using the active computer
        public bool UsingActiveComputer()
        {
            if (activeComputer != null)
                return activeComputer.onComputer;

            return false;
        }

        //Setting all computer screens visabilty to false
        public void CloseComputer()
        {
            activeComputer.onComputer = false;
            passcodeField.text = "";
            activeComputer.EnableInteractionIcon();

            foreach(GameObject g in moduleScreens)
            {
                g.SetActive(false);
            }

        }

        //Logic to load in each computer module and display it to the player
        public void OpenComputer()
        {
            if (activeComputer != _lastActiveComputer)
            {

                //Delete Any Existing Modules
                if (desktopScreen.transform.childCount > 0)
                {
                    for (int i = 0; i < desktopScreen.transform.childCount; i++)
                    {
                        Destroy(desktopScreen.transform.GetChild(i).gameObject);
                    }
                }

                //Add in correct modules
                for (int i = 0; i < activeComputer.modules.Length; i++)
                {
                    Button button = Instantiate(moduleButtonPrefab, desktopScreen.transform).GetComponent<Button>();
                    button.onClick.AddListener(activeComputer.modules[i].DoModule);
                    button.transform.GetChild(0).GetComponent<Image>().sprite = activeComputer.modules[i].moduleIcon;
                    //button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = activeComputer.modules[i].moduleName;
                }
                _lastActiveComputer = activeComputer;
                activeComputer.DisableInteractionIcon();
            }

            activeComputer.onComputer = true;

        }


    }
}
