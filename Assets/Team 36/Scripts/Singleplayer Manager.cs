using System.Collections;
using System.Collections.Generic;
using team36;
using UnityEngine;

namespace Team36
{
    public class SingleplayerManager : MicrogameInputEvents
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

        public Singleplayer player;
        

        public bool isRoundOver = false;
        public bool StartTimer = false;

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
                else if (randomInput == lastInput)
                {

                    i--;
                }
                lastInput = randomInput;
                //print(i + "   " + output);
            }
            //Debug.Log(comboReq);
        }
        public void PlayerWins()
        {
            
                player.health--;
                isRoundOver = true;

                //Debug.Log("Test");
                ComboInitiator();
                Invoke("roundreset", 1);

           
            
        }
        public void gameEnd()
        {
            if (player.health <= 0)
            {
                //p2 wins
            }
        }
        public void roundreset()
        {
            //Debug.Log("reset");
            player.inputplace = 0;
            

            isRoundOver = false;
        }
    }
}