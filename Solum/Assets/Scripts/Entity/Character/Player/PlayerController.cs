using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        private float MoveSpeed => 7f;
        private float Graivty => 20f;

        private Vector3 velocity;
        private CharacterController Controller => GetComponent<CharacterController>();

        public Vector2 LookSensitivity;
        public Transform pCam;
        private float verticalLookRotation;

        private bool CanMove => !ComputerManager.local.UsingActiveComputer();

        #endregion

        #region Methods

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (CanMove)
            {
                Move();
                CameraLook();
            }
        }

        private void Move()
        {
            if (Controller.isGrounded)
            {
                float moveSpeed = MoveSpeed;

                if (Input.GetKey(KeyCode.LeftShift))
                    moveSpeed *= 1.75f;

                float v = Input.GetAxis("Vertical") * moveSpeed;
                float h = Input.GetAxis("Horizontal") * moveSpeed;

                velocity = new Vector3(h, velocity.y, v);
                velocity = transform.TransformDirection(velocity);
            }
            else
            {
                velocity.y -= Graivty * Time.deltaTime;
            }

            Controller.Move(velocity * Time.deltaTime);

        }

        private void CameraLook()
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * LookSensitivity.x);
            verticalLookRotation += Input.GetAxis("Mouse Y") * LookSensitivity.y;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
            pCam.localEulerAngles = Vector3.left * verticalLookRotation;
        }



        #endregion
    }
}
