using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Computer : Interactable
    {

        public bool isOn;

        public bool needsPasscode;
        public string passCode;

        public bool onComputer;

        private string passCodeText;

        public ComputerModule[] modules;

        public override void DoInteract()
        {
            if (isOn)
            {
                ComputerManager.local.SetActiveComputer(this);
                ComputerManager.local.OpenComputer();
            }
        }

        public void CheckPasscode()
        {
            if (passCodeText != null)
            {
                if (passCodeText.Equals(passCode))
                {
                    print("Correct");
                    needsPasscode = false;
                }
                else
                {
                    print("Incorrect");
                }
            }
        }

        public void SetPassCodeText(string text)
        {
            passCodeText = text;
        }

        public void DisableInteractionIcon()
        {
            canShowInteractIcon = false;
        }

        public void EnableInteractionIcon()
        {
            canShowInteractIcon = true;
        }



        private void Start()
        {
            canShowInteractIcon = isOn;
        }

    }
}
