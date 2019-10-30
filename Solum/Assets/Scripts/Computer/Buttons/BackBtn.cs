using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class BackBtn : Button
    {

        public override void DoInteract()
        {
            computer.ChangeScreen("Desktop");
        }

    }
}
