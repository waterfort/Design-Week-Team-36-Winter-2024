using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Team36
{
    public class Inputs : MicrogameInputEvents
    {
        public SpriteRenderer spriteRenderer;
        public Sprite[] sprites;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            spriteRenderer.sprite = sprites[1];
        }
    }
}