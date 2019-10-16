using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class ComputerModule : MonoBehaviour
    {

        public Sprite moduleIcon;
        public string moduleName;

        public virtual void DoModule()
        {
            print("Module has been clicked");
        }

    }
}
