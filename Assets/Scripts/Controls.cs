using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controls : MonoBehaviour {

    public enum controlEnum
    {
        aButton,
        bButton,
        yButton,
        xButton,
        dPadUp,
        dPadDown,
        dPadLeft,
        dPadRight,
        rightBumper,
        leftBumper,
        rightTrigger,
        leftTrigger,
        startButton,
        backButton
    };
    public enum playerEnum
    {
        playerOne,
        playerTwo,
        playerThree,
        playerFour,
    };

    Dictionary<controlEnum, string> controls = new Dictionary<controlEnum, string>()
    {
        { controlEnum.aButton, "aButton"},
        { controlEnum.bButton, "bButton"},
        { controlEnum.yButton, "yButton"},
        { controlEnum.xButton, "xButton"},
        { controlEnum.dPadUp, "dPadUp"},
        { controlEnum.dPadDown, "dPadDown"},
        { controlEnum.dPadLeft, "dPadLeft"},
        { controlEnum.dPadRight, "dPadRight"},
        { controlEnum.rightBumper, "rightBumper"},
        { controlEnum.leftBumper, "leftBumper"},
        { controlEnum.rightTrigger, "rightTrigger"},
        { controlEnum.leftTrigger, "leftTrigger"},
        { controlEnum.startButton, "startButton"},
        { controlEnum.backButton, "backButton"},
    };

}
