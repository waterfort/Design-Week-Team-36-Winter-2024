using System.Collections;
using System.Collections.Generic;
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

        public Outputmanager outputManager;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
    
            display = outputManager.comboReq[inputRef];

            if(display == "Up")
            {
                spriteLocation = 0;
            }
            if (display == "Left")
            {
                spriteLocation = 1;
            }
            if (display == "Right")
            {
                spriteLocation = 2;
            }
            if (display == "Down")
            {
                spriteLocation = 3;
            }
            if (display == "Button1")
            {
                spriteLocation = 4;
            }
            if (display == "Button2")
            {
                spriteLocation = 5;
            }
            if (display == "None")
            {
                spriteLocation = 6;
            }



            spriteRenderer.sprite = sprites[spriteLocation];
        }
    }
}