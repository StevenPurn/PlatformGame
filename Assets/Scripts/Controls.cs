using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Controls : IControls {
    public float getHorizontalDirection()
    {
        throw new NotImplementedException();
    }

    public bool isDetonatorPressed()
    {
        throw new NotImplementedException();
    }

    public bool isJumpPressed()
    {
        throw new NotImplementedException();
    }

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
        playerOne = 1,
        playerTwo,
        playerThree,
        playerFour,
    };


}

public interface IControls{

    bool isJumpPressed();
    bool isDetonatorPressed();
    float getHorizontalDirection();

}
