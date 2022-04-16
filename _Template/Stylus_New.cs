using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zSpace.Core.Extensions;
using zSpace.Core.Sdk;

namespace zSpace.Core.Input
{
    public class Stylus_New : MonoBehaviour
    {
        ZStylus stylus;
        public static bool buttonPressed_0, buttonPressed_1, buttonPressed_2,
                           buttonDown_0, buttonDown_1, buttonDown_2,
                           buttonUp_0, buttonUp_1, buttonUp_2;


        void Start()
        {
            stylus = GameObject.FindObjectOfType<ZStylus>();
        }

        // Update is called once per frame
        void Update()
        {
            if (stylus.ButtonCount == 0)
            {
                return;
            }
            else
            {
                // check if a button is presently held down on any given update frame
                buttonPressed_0 = stylus.GetButton(0);
                buttonPressed_1 = stylus.GetButton(1);
                buttonPressed_2 = stylus.GetButton(2);

                // check if a button was pressed on this frame
                buttonDown_0 = stylus.GetButtonDown(0);
                buttonDown_1 = stylus.GetButtonDown(1);
                buttonDown_2 = stylus.GetButtonDown(2);

                // check if a button was released on this frame
                buttonUp_0 = stylus.GetButtonUp(0);
                buttonUp_1 = stylus.GetButtonUp(1);
                buttonUp_2 = stylus.GetButtonUp(2);
                check_static();
            }
        }

        public void check_static()
        {
            Script_Static.buttonPressed_0 = buttonPressed_0;
            Script_Static.buttonPressed_1 = buttonPressed_1;
            Script_Static.buttonPressed_2 = buttonPressed_2;

            // check if a button was pressed on this frame
            Script_Static.buttonDown_0 = buttonDown_0;
            Script_Static.buttonDown_1 = buttonDown_1;
            Script_Static.buttonDown_2 = buttonDown_2;

            // check if a button was released on this frame
            Script_Static.buttonUp_0 = buttonUp_0;
            Script_Static.buttonUp_1 = buttonUp_1;
            Script_Static.buttonUp_2 = buttonUp_2;
        }
    }
}
