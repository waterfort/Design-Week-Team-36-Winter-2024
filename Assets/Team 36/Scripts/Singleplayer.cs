using System.Collections;
using System.Collections.Generic;
using Team36;
using UnityEngine;
using UnityEngine.InputSystem;

namespace team36
{
    public class Singleplayer : MicrogameInputEvents
    {
        public Vector2 direction;
        public Vector2 lastInput;

        public string currentInput;

        public int inputplace = 0;

        public bool failed = false;

        public float health;

        public float combosCompleted;

        public GameObject scoretext;

        public Animator animator;

        //private float waitTime;


        public SingleplayerManager outputManager;
        private void Start()
        {
            lastInput = Vector2.zero;
            direction = Vector2.zero;
            //outputManager.ComboInitiator();

            combosCompleted = 0;
            health = 2;

            //waitTime = 1;
        }
        private void Update()
        {
            if (outputManager.isRoundOver == false)
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
                if (currentInput == "None")
                {

                    lastInput = direction;
                }

            }

        }

        protected override void OnButton1Pressed(InputAction.CallbackContext context)
        {

            // Debug.Log("Do action 1");
            if (outputManager.isRoundOver == false)
            {
                currentInput = "Button1";
                checkInput();
            }

        }



        protected override void OnButton2Pressed(InputAction.CallbackContext context)
        {

            // Debug.Log("Do action 2");
            if (outputManager.isRoundOver == false)
            {
                currentInput = "Button2";
                checkInput();
            }

        }

        public void clearInput()
        {
            //call this in between combos/rounds
            lastInput = Vector2.zero;
        }
        public void checkInput()
        {

            if (currentInput == outputManager.comboReq[inputplace] && failed == false && outputManager.isRoundOver == false)
            {
                //Debug.Log("good");
                currentInput = "None";
                inputplace++;
                animator.SetTrigger("inputSuccess");

            }
            else if (currentInput != outputManager.comboReq[inputplace] && failed == false && outputManager.isRoundOver == false)
            {
                //Debug.Log("bad");

                currentInput = "None";


                //inputplace = 0;
                failed = true;


            }
            if (inputplace == 4)
            {
                outputManager.StartTimer = true;
                outputManager.PlayerWins();
                combosCompleted++;
                scoretext.SendMessage("ScoreIncrease");

                // waitTime = 1;

            }

        }
    }
}
