using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public static class InputManager {

    public enum playerEnum
    {
        playerOne = 1,
        playerTwo,
        playerThree,
        playerFour,
    };

    public static Dictionary<string, KeyCode> playerOneControls = new Dictionary<string, KeyCode>()
    {
        { "Jump", KeyCode.Joystick1Button0 },
        { "SwitchWeapons", KeyCode.Joystick1Button3},
        { "Shoot", KeyCode.Joystick1Button10 }
    };

    public static Dictionary<string, KeyCode> playerTwoControls = new Dictionary<string, KeyCode>()
    {
        { "Jump", KeyCode.Joystick2Button0 },
        { "SwitchWeapons", KeyCode.Joystick2Button3},
        { "Shoot", KeyCode.Joystick2Button10 }
    };

    public static Dictionary<string, KeyCode> playerThreeControls = new Dictionary<string, KeyCode>()
    {
        { "Jump", KeyCode.Joystick3Button0 },
        { "SwitchWeapons", KeyCode.Joystick3Button3},
        { "Shoot", KeyCode.Joystick3Button10 }
    };

    public static Dictionary<string, KeyCode> playerFourControls = new Dictionary<string, KeyCode>()
    {
        { "Jump", KeyCode.Joystick4Button0 },
        { "SwitchWeapons", KeyCode.Joystick4Button3},
        { "Shoot", KeyCode.Joystick4Button10 }
    };

    public static bool GetButtonDown(playerEnum player, string button)
    {
        switch (player)
        {
            case playerEnum.playerOne:
                if (playerOneControls.ContainsKey(button))
                {
                    return Input.GetKeyDown(playerOneControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + " button not found");
                    return false;
                }
            case playerEnum.playerTwo:
                if (playerTwoControls.ContainsKey(button))
                {
                    return Input.GetKeyDown(playerTwoControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + "button not found");
                    return false;
                }
            case playerEnum.playerThree:
                if (playerThreeControls.ContainsKey(button))
                {
                    return Input.GetKeyDown(playerThreeControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + "button not found");
                    return false;
                }
            case playerEnum.playerFour:
                if (playerFourControls.ContainsKey(button))
                {
                    return Input.GetKeyDown(playerFourControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + "button not found");
                    return false;
                }
            default:
                return false;
        }
    }

    public static string[] GetButtonNames()
    {
        return playerOneControls.Keys.ToArray();
    }

    public static float GetAxis(playerEnum player, string axis)
    {
        float amount = 0.0f;
        amount = Input.GetAxis(player.ToString() + axis);
        return amount;
    }

    public static bool GetButton(playerEnum player, string button)
    {
        switch (player)
        {
            case playerEnum.playerOne:
                if (playerOneControls.ContainsKey(button))
                {
                    return Input.GetKey(playerOneControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + " button not found");
                    return false;
                }
            case playerEnum.playerTwo:
                if (playerTwoControls.ContainsKey(button))
                {
                    return Input.GetKey(playerTwoControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + "button not found");
                    return false;
                }
            case playerEnum.playerThree:
                if (playerThreeControls.ContainsKey(button))
                {
                    return Input.GetKey(playerThreeControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + "button not found");
                    return false;
                }
            case playerEnum.playerFour:
                if (playerFourControls.ContainsKey(button))
                {
                    return Input.GetKey(playerFourControls[button]);
                }
                else
                {
                    Debug.LogWarning(button + "button not found");
                    return false;
                }
            default:
                return false;
        }
    }
}