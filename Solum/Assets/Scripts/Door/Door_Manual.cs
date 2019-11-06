using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wreckless
{
    public class Door_Manual : Interactable
    {

        public Vector3[] doorPath;
        public float moveSpeed;
        public Transform door;

        private float percent;

        private bool open;

        public override void DoInteract()
        {
            open = !open;
        }

        private void Start()
        {
            percent = 0;
            open = false;
        }

        private void Update()
        {
            if (open)
                percent += Time.deltaTime * moveSpeed;
            else
                percent -= Time.deltaTime * moveSpeed;

            percent = Mathf.Clamp(percent, 0, 100);

            iTween.PutOnPath(door, doorPath, percent / 100);
        }

    }
}
