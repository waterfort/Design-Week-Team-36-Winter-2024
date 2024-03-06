using System.Collections;
using System.Collections.Generic;
using team36;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
namespace Team36
{
    public class Inputs : MicrogameInputEvents
    {
        public SpriteRenderer spriteRenderer;
        public Sprite[] sprites;

        public int inputRef = 0;
        public string display;
        public int spriteLocation;

        private float waitTime = 1;
        

        //6 is for success, 14 for fail
        public int buttonstate = 0;


        public Outputmanager outputManager;
        public Player player;

        // Start is called before the first frame update
        void Start()
        {
            waitTime = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if(outputManager.isRoundOver == true)
            {
                //none of this works yet cause it gets skipped over if u ever set is round over back to false either here or in output manager.
                print("hi");
                waitTime = 1;
                buttonstate = 0;
                player.inputplace = 0;
                
                
            }

            if (player.inputplace > inputRef)
            {
                buttonstate = 6;
            }
            if (player.inputplace == inputRef && player.failed == true)
            {
                //Debug.Log(this + "failed");
                buttonstate = 12;
                
                waitTime -= Time.deltaTime;
                if (waitTime < 0)
                {
                    Debug.Log("fail");
                    buttonstate = 0;
                    player.failed = false;
                    waitTime = 1;
                    player.inputplace = 0;

                }



            }
            if (player.inputplace <= inputRef && player.failed == false)
            {
                buttonstate = 0;
            }
            

            display = outputManager.comboReq[inputRef];

            if(display == "Up")
            {
                spriteLocation = 0 + buttonstate;
            }
            if (display == "Left")
            {
                spriteLocation = 1 + buttonstate;
            }
            if (display == "Right")
            {
                spriteLocation = 2 + buttonstate;
            }
            if (display == "Down")
            {
                spriteLocation = 3 + buttonstate;
            }
            if (display == "Button1")
            {
                spriteLocation = 4 + buttonstate;
            }
            if (display == "Button2")
            {
                spriteLocation = 5 + buttonstate;
            }
            if (display == "None")
            {
                spriteLocation = 6 + buttonstate;
            }

            

            spriteRenderer.sprite = sprites[spriteLocation];

        }
        
    }
}