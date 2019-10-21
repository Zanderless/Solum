using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Interact : MonoBehaviour
    {

        public GameObject HUDRecticle;

        private Interactable currentInteractable;

        private void Start()
        {
            HUDRecticle.SetActive(false);
        }

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

                    HUDRecticle.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        interactable.DoInteract();
                    }

                }
                else
                {
                    HUDRecticle.SetActive(false);
                }
            }
            else
                HUDRecticle.SetActive(false);


        }

    }
}
