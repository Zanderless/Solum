using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class AreaChangeTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            
            if(other.tag == "Player")
            {
                ScreenMessageSystem.Instance.ShowMessage("Debug Room");
            }

        }
    }
}
