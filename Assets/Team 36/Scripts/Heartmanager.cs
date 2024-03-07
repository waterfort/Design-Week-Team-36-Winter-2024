using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team36
{
    public class Heartmanager : MonoBehaviour
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
              
        }

        public void FullHeart()
        {
            spriteRenderer.sprite = sprites[0];
        }

        public void EmptyHeart()
        {
            spriteRenderer.sprite = sprites[1];
        }
    }
}