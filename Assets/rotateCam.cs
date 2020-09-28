using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class rotateCam : MonoBehaviour
{
    MyCharacterActions characterActions;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        characterActions = new MyCharacterActions();
        characterActions.lLeft.AddDefaultBinding(InputControlType.RightStickLeft);
        characterActions.lRight.AddDefaultBinding(InputControlType.RightStickRight);
        characterActions.lUp.AddDefaultBinding(InputControlType.RightStickUp);
        characterActions.lDown.AddDefaultBinding(InputControlType.RightStickDown);

        characterActions.lLeft.AddDefaultBinding(Mouse.NegativeX);
        characterActions.lRight.AddDefaultBinding(Mouse.PositiveX);
        characterActions.lUp.AddDefaultBinding(Mouse.NegativeY);
        characterActions.lDown.AddDefaultBinding(Mouse.PositiveY);
    }

    // Update is called once per frame
    void Update()
    {
        if(characterActions.Look.X != 0)
        {
            transform.Rotate(0, characterActions.Look.LastValue.x * Time.deltaTime * 45, 0);
        }
    }
}
