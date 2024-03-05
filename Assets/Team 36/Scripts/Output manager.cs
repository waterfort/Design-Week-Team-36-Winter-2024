using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team36
{
    public class Outputmanager : MicrogameInputEvents
    {
        private Vector2 playerInputDirection;

        private Vector2[] possibleDirections = {
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, -1),
            new Vector2(-1, 0),
            
         };



        private Vector2 playerOutputDirection;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}