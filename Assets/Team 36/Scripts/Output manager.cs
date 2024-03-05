using System.Collections;
using System.Collections.Generic;
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
                print(i + "   " + output);
            }
            //Debug.Log(comboReq);
        }   
    }
}