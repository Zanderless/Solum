using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class PowerBox : Interactable
    {

        public Computer computer;

        public override void DoInteract()
        {
            if (canUse)
            {
                computer.isOn = true;
                canUse = false;
            }
        }

    }
}
