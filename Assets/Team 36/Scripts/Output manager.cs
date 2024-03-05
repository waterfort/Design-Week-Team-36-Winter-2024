using System.Collections;
using System.Collections.Generic;
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
        
    
    


        private Vector2 playerOutputDirection;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }
        void ComboInitiator()
        {
            int randomInput = Random.Range(0, inputs.Length);
            string output = inputs[randomInput];
            Debug.Log(output);
            Debug.Log(output);
        }
    }
}