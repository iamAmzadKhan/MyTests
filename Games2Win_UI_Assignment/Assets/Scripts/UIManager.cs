using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public Image m_SelectedButtonImage;

    public Text m_SelectedButtonText;

    public bool m_ToggleSelection;

    public bool m_Flipped;

    public Sprite m_SteerImage;

    public Sprite m_TouchImage;

    public Sprite m_TiltImage;

    public Sprite m_SteerFlipImage;

    public Sprite m_TouchFlipImage;

    public Image m_Steer;

    public Image m_Touch;

    public Image m_Tilt;

    public Slider m_MusicSlider;

    public Slider m_SFXSlider;

    public Slider m_SteerSensitivitySlider;

    public float tempVal;

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
        
        m_MusicSlider.value = PlayerPrefs.GetFloat(m_MusicSlider.gameObject.name, 0);
        m_SFXSlider.value = PlayerPrefs.GetFloat(m_SFXSlider.gameObject.name, 0);
        m_SteerSensitivitySlider.value = PlayerPrefs.GetFloat(m_SteerSensitivitySlider.gameObject.name, 0);


        m_MusicSlider.onValueChanged.AddListener((tempVal)=>{ValueChangeCheck(m_MusicSlider);});
        m_SFXSlider.onValueChanged.AddListener((tempVal)=> {ValueChangeCheck(m_SFXSlider);});
        m_SteerSensitivitySlider.onValueChanged.AddListener((tempVal)=> {ValueChangeCheck(m_SteerSensitivitySlider);});

    }

    void FlipControls()
    {
        m_Flipped = !m_Flipped;

        if (m_Flipped)
        {
            m_Steer.sprite = m_SteerFlipImage;
            m_Touch.sprite = m_TouchFlipImage;
        }
        else
        {
            m_Steer.sprite = m_SteerImage;
            m_Touch.sprite = m_TouchImage;
        }
    }


    void ValueChangeCheck(Slider p_Slider)
    {
            tempVal = p_Slider.value;
            PlayerPrefs.SetFloat(p_Slider.gameObject.name, tempVal);
            Debug.Log("Name of the slider " + p_Slider.gameObject.name + " and its value is " + PlayerPrefs.GetFloat(p_Slider.gameObject.name));
//            Debug.Log("Something is printed");
      
//        PlayerPrefs.SetFloat(slider.gameObject.name, slider.value);
    }
    void ToggleSelect()
    {
        m_ToggleSelection = !m_ToggleSelection;

        if (m_ToggleSelection)
        {
            GameObject go = EventSystem.current.currentSelectedGameObject;
            string name = go.name;
            if (name.Equals("SteerButton") || name.Equals("TouchButton") || name.Equals("TiltButton"))
            {
                m_SelectedButtonImage = go.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Image>();
                m_SelectedButtonImage.color = new Color(255, 255, 255, 255);
                m_SelectedButtonText = go.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
                m_SelectedButtonText.text = "Selected";
            }
            else if (name.Equals("ManualDriveButton"))
            {
                m_SelectedButtonImage = go.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Image>();
                m_SelectedButtonImage.color = new Color(255, 255, 255, 255);
                m_SelectedButtonText = go.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
                m_SelectedButtonText.text = "ON";
                go.transform.GetChild(2).GetComponent<Slider>().value = 1;

            }
        }
        else
        {
            GameObject go = EventSystem.current.currentSelectedGameObject;
            string name = go.name;
            if (name.Equals("SteerButton") || name.Equals("TouchButton") || name.Equals("TiltButton"))
            {
                m_SelectedButtonImage = go.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Image>();
                m_SelectedButtonImage.color = new Color(255, 255, 255, 0);
                m_SelectedButtonText = go.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
                m_SelectedButtonText.text = "Select";
            }
            else if (name.Equals("ManualDriveButton"))
            {
                m_SelectedButtonImage = go.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Image>();
                m_SelectedButtonImage.color = new Color(255, 255, 255, 0);
                m_SelectedButtonText = go.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
                m_SelectedButtonText.text = "OFF";
                go.transform.GetChild(2).GetComponent<Slider>().value = 0;
            }
             
        }
    }

    void Update()
    {
        
    }
    public void OnClickButton(string p_ButtonName)
    {
//        Debug.Log(EventSystem.current.currentSelectedGameObject.transform.GetChild(2).transform.GetChild(0).transform.name);
       
        ToggleSelect();
        if (m_ToggleSelection)
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
                    FlipControls();
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
}
