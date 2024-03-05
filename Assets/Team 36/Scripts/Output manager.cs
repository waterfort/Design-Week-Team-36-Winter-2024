using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

        int lastInput;
        public int combolength = 4;
    
    


        private Vector2 playerOutputDirection;
        // Start is called before the first frame update
        void Start()
        {
                ComboInitiator();
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        void ComboInitiator()
        {
            for (int i = 0; i < combolength; i++)
            {
                int randomInput = Random.Range(0, inputs.Length);
                string output = inputs[randomInput];

                if (randomInput != lastInput)
                {
                    Debug.Log(output);
                }
                else if(randomInput == lastInput)
                {
                    Debug.Log("same input retrying");
                    i-- ;
                    
                }
                lastInput = randomInput;
            }
        }   
    }
}