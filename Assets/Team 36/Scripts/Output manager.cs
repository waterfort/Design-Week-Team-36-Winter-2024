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

        public bool isGameOver = false;




        private Vector2 playerOutputDirection;

        public Animator animatorP1;
        public Animator animatorP2;
        public Animator m_animator;

        public Heartmanager p1Heart1;
        public Heartmanager p1Heart2;
        public Heartmanager p1Heart3;
        public Heartmanager p2Heart1;
        public Heartmanager p2Heart2;
        public Heartmanager p2Heart3;

        public GameObject goHeartp1a;
        public GameObject goHeartp1b;
        public GameObject goHeartp1c;
        public GameObject goHeartp2a;
        public GameObject goHeartp2b;
        public GameObject goHeartp2c;
        // Start is called before the first frame update
        void Start()
        {
            ComboInitiator();
            isRoundOver = false;
            waitTime = 1;
            player1.health = 3;
            player2.health = 3;

            isGameOver = false;

            goHeartp1a.SetActive(true);
            goHeartp1b.SetActive(true);
            goHeartp1c.SetActive(true);
            goHeartp2a.SetActive(true);
            goHeartp2b.SetActive(true);
            goHeartp2c.SetActive(true);


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

                isGameOver = true;
                //animatorP1.SetTrigger("loser");
               // animatorP2.SetTrigger("winner");

                Invoke("gameEnd", 0.5f);

                
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

                isGameOver = true;
                //animatorP1.SetTrigger("winner");
                //animatorP2.SetTrigger("loser");

                Invoke("gameEnd", 0.5f);


                


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
                animatorP1.SetTrigger("punch");
                m_animator.SetTrigger("masterSuccess");
                player2.health--;
                isRoundOver = true;

                //Debug.Log("Test");
                ComboInitiator();
                Invoke("roundreset", 1);

            }
            if (winner.name == "Player 2 Controller")
            {
                animatorP1.SetTrigger("wasPunched");
                animatorP2.SetTrigger("punch");
                player1.health--;
                isRoundOver = true;

                //Debug.Log("Test");
                ComboInitiator();
                Invoke("roundreset", 1);
            }
        }
        public void gameEnd()
        {
            goHeartp1a.SetActive(false);
            goHeartp1b.SetActive(false);
            goHeartp1c.SetActive(false);

            goHeartp2a.SetActive(false);
            goHeartp2b.SetActive(false);
            goHeartp2c.SetActive(false);


            if (player1.health <= 0)
            {

                //p2 wins
                animatorP1.SetTrigger("loser");
                animatorP2.SetTrigger("winner");
                ReportGameCompletedEarly();
                player1.health = 3;

                
                
            }
            if (player2.health <= 0)
            {

                //p1 wins
                animatorP1.SetTrigger("winner");
                animatorP2.SetTrigger("loser");
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