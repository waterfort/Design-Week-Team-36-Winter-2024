using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
        public bool StartTimer = false;
        

        private Vector2 playerOutputDirection;

        public Animator animatorP1;
        public Animator animatorP2;

        public Heartmanager p1Heart1;
        public Heartmanager p1Heart2;
        public Heartmanager p1Heart3;
        public Heartmanager p2Heart1;
        public Heartmanager p2Heart2;
        public Heartmanager p2Heart3;
        // Start is called before the first frame update
        void Start()
        {
            ComboInitiator();
            isRoundOver = false;
            waitTime = 1;
            player1.health = 3;
            player2.health = 3;
            
        }

        // Update is called once per frame
        void Update()
        {
            
            //updatehearts here
            if(player1.health == 3)
            {
                p1Heart1.FullHeart();
                p1Heart2.FullHeart();
                p1Heart3.FullHeart();
            }
            if (player1.health == 2)
            {
                p1Heart1.EmptyHeart();
                p1Heart2.FullHeart();
                p1Heart3.FullHeart();
            }
            if (player1.health == 1)
            {
                p1Heart1.EmptyHeart();
                p1Heart2.EmptyHeart();
                p1Heart3.FullHeart();
            }
            if (player1.health == 0)
            {
                p1Heart1.EmptyHeart();
                p1Heart2.EmptyHeart();
                p1Heart3.EmptyHeart();
                
                gameEnd();
            }
            if (player2.health == 3)
            {
                p2Heart1.FullHeart();
                p2Heart2.FullHeart();
                p2Heart3.FullHeart();
            }
            if (player2.health == 2)
            {
                p2Heart1.EmptyHeart();
                p2Heart2.FullHeart();
                p2Heart3.FullHeart();
            }
            if (player2.health == 1)
            {
                p2Heart1.EmptyHeart();
                p2Heart2.EmptyHeart();
                p2Heart3.FullHeart();
            }
            if (player2.health == 0)
            {
                p2Heart1.EmptyHeart();
                p2Heart2.EmptyHeart();
                p2Heart3.EmptyHeart();
                
                gameEnd();
            }

            if (StartTimer == true)
            {
                waitTime -= Time.deltaTime;
                if (waitTime < 0)
                { 
                    StartTimer = false;
                }       
            }

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
                animatorP2.SetTrigger("wasPunched");
                player2.health--;
                isRoundOver = true;

                //Debug.Log("Test");
                ComboInitiator();
                Invoke("roundreset", 1);

            }
            if (winner.name == "Player 2 Controller")
            {
                animatorP1.SetTrigger("wasPunched");
                player1.health--;
                isRoundOver = true;

                //Debug.Log("Test");
                ComboInitiator();
                Invoke("roundreset", 1);
            }
        }
        public void gameEnd()
        {
            
            if (player1.health <= 0)
            {
                
                //p2 wins
                ReportGameCompletedEarly();
                player1.health = 3;
                
                
            }
            if (player2.health <= 0)
            {
               
                //p1 wins
                ReportGameCompletedEarly();
                player2.health = 3;

                
            }
        }
        public void roundreset()
        {
            //Debug.Log("reset");
            player2.inputplace = 0;
            player1.inputplace = 0;

            isRoundOver = false;
        }
    }
}