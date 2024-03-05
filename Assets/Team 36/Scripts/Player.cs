using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace team36
{ 
    public class Player : MicrogameInputEvents
    {
        public Vector2 direction;
        public Vector2 lastInput;
        private void Start()
        {
            lastInput = Vector2.zero;
            direction = Vector2.zero;
        }
        private void Update()
        {
            direction = stick.normalized;

            if (direction.x == 1 && lastInput.x != 1)
            {
                //right
                Debug.Log("Right");
                lastInput = direction;
            }
            if (direction.x == -1 && lastInput.x != -1)
            {
                //left
                Debug.Log("Left");
                lastInput = direction;
            }
            if (direction.y == 1 && lastInput.y != 1)
            {
                //up
                Debug.Log("Up");
                lastInput = direction;
            }
            if (direction.y == -1 && lastInput.y != -1)
            {
                //down
                Debug.Log("Down");
                lastInput = direction;
            }
        }

        protected override void OnButton1Pressed(InputAction.CallbackContext context)
        {

            Debug.Log("Do action 1");

        }

        protected override void OnButton1Released(InputAction.CallbackContext context)
        {

            Debug.Log("Stop action 1");

        }

        protected override void OnButton2Pressed(InputAction.CallbackContext context)
        {

            Debug.Log("Do action 2");

        }

        protected override void OnButton2Released(InputAction.CallbackContext context)
        {

            Debug.Log("Stop action 2");

        }
    }

}