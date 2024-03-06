using System.Collections;
using System.Collections.Generic;
using team36;
using Unity.VisualScripting;
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

        //6 is for success, 14 for fail
        public int buttonstate = 0;


        public Outputmanager outputManager;
        public Player player;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (player.inputplace > inputRef)
            {
                buttonstate = 6;
            }
            if (player.inputplace <= inputRef)
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