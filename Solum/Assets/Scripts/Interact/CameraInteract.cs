//This is used to interact with objects that have the interactable script (or any that inherits it) and world space UI elements that have the layer Interactable
//Please place this on the Camera that is a child of the Player object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wreckless
{
    public class CameraInteract : MonoBehaviour
    {

        public GameObject playerRecticle;
        public float interactDistance = 5f;

        private RaycastHit hit;
        private Ray Ray => new Ray(transform.position, transform.forward);

        private void Start()
        {
            playerRecticle.SetActive(false);
        }

        private void Update()
        {

            Raycast();

        }

        private void Raycast()
        {

            if (Physics.Raycast(Ray, out hit, interactDistance))
            {

                if (hit.transform.gameObject.layer == 9)
                {
                    playerRecticle.SetActive(true);

                    Interactable interactable = hit.transform.GetComponent<Interactable>();

                    if(interactable != null)
                    {
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            interactable.DoInteract();
                        }
                    }

                }
                else
                    playerRecticle.SetActive(false);

            }
            else
                playerRecticle.SetActive(false);


        }

    }
}
