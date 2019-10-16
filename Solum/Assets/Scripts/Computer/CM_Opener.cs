using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class CM_Opener : ComputerModule
    {

        public Opener opener;

        public override void DoModule()
        {
            opener.DoOpen();
        }

    }
}
