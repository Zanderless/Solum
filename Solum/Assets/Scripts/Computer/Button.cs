using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wreckless
{
    public class Button : Interactable
    {

        public Computer computer;

        private Image Image => GetComponent<Image>();

        private void Update()
        {
            if (canUse)
                Image.color = computer.buttonEnable;
            else
                Image.color = computer.buttonDisable;

        }

    }
}
