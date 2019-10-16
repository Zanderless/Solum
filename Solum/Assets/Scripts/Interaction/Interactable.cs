using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{

    public GameObject interactIcon;
    private Transform Player => GameObject.FindGameObjectWithTag("Player").transform;
    protected bool canShowInteractIcon = true;

    private void Update()
    {

        if (interactIcon != null)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            interactIcon.SetActive(dist <= 5 && canShowInteractIcon);
        }

    }

    public virtual void DoInteract()
    {
        print("Do stuff");
    }
}
