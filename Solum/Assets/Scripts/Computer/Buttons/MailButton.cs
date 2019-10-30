using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class MailButton : Button
    {

        public override void DoInteract()
        {
            computer.ChangeScreen("Mail Screen");
        }

    }
}
