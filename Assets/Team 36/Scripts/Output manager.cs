using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using team36;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

namespace Team36
{
    public class Outputmanager : MicrogameInputEvents
    {
        string[] inputs = { 
            "Up",
            "Down",
            "Left",
            "Right",
            "Button1",
            "Button2" 
        };

        public string[] comboReq;

        int lastInput;
        public int combolength = 4;
        public float waitTime = 1;

        public Player player1;
        public Player player2;

        public bool isRoundOver = false;

        private Vector2 playerOutputDirection;
        // Start is called before the first frame update
        void Start()
        {
            ComboInitiator();
            isRoundOver = false;
            waitTime = 1;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void ComboInitiator()
        {
            comboReq = new string[combolength];
            for (int i = 0; i < combolength; i++)
            {
                int randomInput = Random.Range(0, inputs.Length);
                string output = inputs[randomInput];

                if (randomInput != lastInput)
                {
                    comboReq[i] = output;
                }
                else if(randomInput == lastInput)
                {
                    
                    i-- ;
                }
                lastInput = randomInput;
               //print(i + "   " + output);
            }
            //Debug.Log(comboReq);
        }
        public void PlayerWins(team36.Player winner)
        {
            print(winner.name);
            if (winner.name == "Player 1 Controller")
            {
                player2.health--;
                waitTime -= Time.deltaTime;
                roundreset();
                ComboInitiator();
            }
            if (winner.name == "Player 2 Controller")
            {
                player1.health--;
                isRoundOver = true;
                //waitTime -= Time.deltaTime;
               // if (waitTime < 0)
               //{
                    roundreset();
                    ComboInitiator();
                   // waitTime = 1;
                //}
            }
        }
        public void gameEnd()
        {
            if (player1.health <= 0)
            {
                //p2 wins
            }
            if (player2.health <= 0)
            {
                //p1 wins
            }
        }
        public void roundreset()
        {
            player2.inputplace = 0;
            player1.inputplace = 0;
            isRoundOver = false;
        }
    }
}