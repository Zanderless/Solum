using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class SlidingDoor : Opener
    {

        public Vector3 closePos;
        public Vector3 openPos;
        private Vector3 CurrentPos => transform.position;

        public override void DoOpen()
        {
            iTween.MoveTo(this.gameObject, openPos, 20f);
        }

    }
}
