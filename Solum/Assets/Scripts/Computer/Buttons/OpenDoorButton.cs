using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class OpenDoorButton : Button
    {

        public Door door;

        public override void DoInteract()
        {
            door.OpenDoor();
            canUse = false;
        }
    }
}
