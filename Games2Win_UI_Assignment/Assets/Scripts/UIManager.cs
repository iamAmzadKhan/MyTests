using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject m_ControlSelectionFrame;
    public GameObject m_DriveSelectionFrame;
    public GameObject m_MusicSelectionFrame;
    public GameObject m_SFXSelectionFrame;
    public GameObject m_ButtonsCollectionFrame;


    public enum ControlType
    {
        Steering,
        Arrows,
        Tilt,
        None
    };

    public ControlType m_ControlType = ControlType.None;

    public void SwitchControls(ControlType p_ControlType)
    {
        m_ControlType = p_ControlType;
        switch (p_ControlType)
        {
            
            case ControlType.Steering:
                Debug.Log("<color=green>Steering Control</color> is Selected");
                break;

            case ControlType.Arrows:
                Debug.Log("<color=blue>Touch Control</color> is Selected");

                break;

            case ControlType.Tilt:
                Debug.Log("<color=red>Tilt Control</color> is Selected");

                break;

            default:
                break;
        }

    }

    void Start()
    {
        
    }


    public void OnClickButton(string p_ButtonName)
    {
        switch (p_ButtonName)
        {
            case "SteerButton":
                Debug.Log("<color=green>Steering Control</color> is Selected");

                break;
            case "TouchButton":
                Debug.Log("<color=blue>Touch Control</color> is Selected");

                break;
            case "TiltButton":
                Debug.Log("<color=red>Tilt Control</color> is Selected");

                break;
            case "FlipControlButton":
                Debug.Log("<color=magenta>Flip Control</color> is Selected");

                break;
            case "ManualDriveButton":
                Debug.Log("<color=magenta>Manual Driver</color> is Selected");

                break;
            case "BackButton":
                Debug.Log("<color=magenta>Back Button</color> is Selected");

                break;
            case "WheelButton":
                Debug.Log("<color=magenta>Wheel Button</color> is Selected");

                break;
            case "HelpButton":
                Debug.Log("<color=magenta>Help Button</color> is Selected");

                break;

            case "PlayGamesButton":
                Debug.Log("<color=magenta>Play Games Button</color> is Selected");

                break;
            case "Games2WinButton":
                Debug.Log("<color=magenta>Games2Win Button</color> is Selected");

                break;
            case "ChooseInstructorButton":
                Debug.Log("<color=magenta>Choose Instructor Button</color> is Selected");

                break;
            case "WhatsappButton":
                Debug.Log("<color=magenta>Whatsapp Button</color> is Selected");

                break;
            default:
                break;
        }
    }
}
