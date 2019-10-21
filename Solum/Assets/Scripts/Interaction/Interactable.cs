using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{

    public virtual void DoInteract()
    {
        print("Do stuff");
    }
}
