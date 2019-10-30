using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Entity : MonoBehaviour
    {
        
        public Vector3 Position
        {
            get { return transform.position; }
            set
            {
                transform.position = value;
            }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set
            {
                transform.rotation = value;
            }
        }

    }
}
