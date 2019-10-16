using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Interact : MonoBehaviour
    {

        public GameObject interactNotifier;

        private Interactable currentInteractable;

        private void Update()
        {
            RayCast();
        }

        private void RayCast()
        {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
            {

                IInteractable interactable = hit.transform.GetComponent<Interactable>() as IInteractable;

                if (interactable != null)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        interactable.DoInteract();
                    }

                }

            }

        }

    }
}
