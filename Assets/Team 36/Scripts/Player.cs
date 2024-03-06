using System.Collections;
using System.Collections.Generic;
using Team36;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace team36
{ 
    public class Player : MicrogameInputEvents
    {
        public Vector2 direction;
        public Vector2 lastInput;

        public string currentInput;

        public int inputplace = 0;
       

        public Outputmanager outputManager;
        private void Start()
        {
            lastInput = Vector2.zero;
            direction = Vector2.zero;
            //outputManager.ComboInitiator();

        }
        private void Update()
        {

            direction = stick.normalized;

            if (direction.x == 1 && lastInput.x != 1)
            {
                //right
              //  Debug.Log("Right");
                currentInput = "Right";
                lastInput = direction;
                checkInput();
            }
            if (direction.x == -1 && lastInput.x != -1)
            {
                //left
               // Debug.Log("Left");
                currentInput = "Left";
                lastInput = direction;
                checkInput();
            }
            if (direction.y == 1 && lastInput.y != 1)
            {
                //up
               // Debug.Log("Up");
                currentInput = "Up";
                lastInput = direction;
                checkInput();
            }
            if (direction.y == -1 && lastInput.y != -1)
            {
                //down
                //Debug.Log("Down");
                currentInput = "Down";
                lastInput = direction;
                checkInput();
            }

            


        }

        protected override void OnButton1Pressed(InputAction.CallbackContext context)
        {

           // Debug.Log("Do action 1");
            currentInput = "Button1";
            checkInput();

        }

       

        protected override void OnButton2Pressed(InputAction.CallbackContext context)
        {

           // Debug.Log("Do action 2");
            currentInput = "Button2";
            checkInput();

        }

        public void clearInput()
        {
            //call this in between combos/rounds
            lastInput = Vector2.zero;
        }
        public void checkInput()
        {
           
            if (currentInput == outputManager.comboReq[inputplace])
            {
                Debug.Log("good");
                currentInput = "None";
                inputplace ++;
                    
            }
            if (inputplace == 4)
            {
                Debug.Log(this + " Wins");
                inputplace = 0;

            }
   
        }
    }
}