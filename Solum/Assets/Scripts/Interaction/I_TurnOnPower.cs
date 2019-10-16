using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class I_TurnOnPower : Interactable
    {

        public GameObject[] lights;
        public Computer[] computers;

        private bool isOn;

        public override void DoInteract()
        {

            if (!isOn)
            {
                foreach(GameObject l in lights)
                {
                    l.SetActive(true);
                }
                foreach(Computer c in computers)
                {
                    c.isOn = true;
                }
                isOn = true;
                canShowInteractIcon = false;
            }

        }

        private void Start()
        {
            foreach (GameObject l in lights)
            {
                l.SetActive(false);
            }
            foreach (Computer c in computers)
            {
                c.isOn = false;
            }
        }

    }
}
