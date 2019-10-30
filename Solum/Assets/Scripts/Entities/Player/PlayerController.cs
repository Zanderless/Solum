using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]
    public class PlayerController : Entity
    {

        #region Variables

        //Movement
        private float MoveSpeed => 7f;
        private float SprintMultiplier => 2f;
        private float Gravity => 20f;

        private Vector3 velocity;
        private CharacterController Controller => GetComponent<CharacterController>();

        //Camera
        public Vector2 LookSensitivity;
        public Transform pCam;
        private float verticalLookRotation;

        #endregion

        #region Methods

        private void Start()
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        private void Update()
        {
            Movement();
            CameraLook();
        }

        private void Movement()
        {

            float h = Input.GetAxis("Horizontal") * MoveSpeed;
            float v = Input.GetAxis("Vertical") * MoveSpeed;

            var moveDir = new Vector3(h, 0, v);
            if (Input.GetKey(KeyCode.LeftShift)) moveDir *= SprintMultiplier;

            velocity = new Vector3(moveDir.x, velocity.y, moveDir.z);
            velocity = transform.TransformDirection(velocity);

            velocity.y -= Gravity * Time.deltaTime;

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
