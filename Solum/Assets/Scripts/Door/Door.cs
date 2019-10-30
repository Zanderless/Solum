using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Door : MonoBehaviour
    {

        //Delete Later
        public Vector3 openPos;

        public void OpenDoor()
        {
            transform.position = openPos;
        }

    }
}
