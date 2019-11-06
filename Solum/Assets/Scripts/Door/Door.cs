using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Door : MonoBehaviour
    {

        public Animator anim;

        public void OpenDoor()
        {
            anim.SetTrigger("Open");
        }

    }
}
