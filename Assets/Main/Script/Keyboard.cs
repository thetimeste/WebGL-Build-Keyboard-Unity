using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    
    public InputField inputFieldEmail;
    public InputField inputFieldPassword;
    public Button uppercaseButton;
    public GameObject keyboardCanvas;
    bool inputFieldEmailClicked=false;
    bool inputFieldPasswordClicked = false;
    bool uppercasePressed = false;
    public GameObject uppercaseText;





    public void Start()
    {

        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

   
    public void onInputFieldEmailClick()
    {
        inputFieldEmailClicked = true;
        inputFieldPasswordClicked = false;
        Debug.Log("inputfieldemail clicked");
    }
    public void onInputFieldPasswordClick()
    {
        inputFieldEmailClicked = false;
        inputFieldPasswordClicked = true;
        Debug.Log("inputfieldpassword clicked");
    }

    public void onKeyboardButtonClick()
    {
        string buttonPressed = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(buttonPressed);
        if (buttonPressed.Equals("UPPER"))
        {
            if (uppercasePressed)
            {
                uppercaseText.GetComponent<TextMeshProUGUI>().text = "uppercase: disabled";
                uppercaseButton.GetComponent<Image>().color = Color.white;
                uppercasePressed = false;
            }
            else
            {
                uppercaseText.GetComponent<TextMeshProUGUI>().text = "uppercase: enabled";
                uppercaseButton.GetComponent<Image>().color = Color.gray;
                uppercasePressed = true;
            }
        }
        else
        {
            if (uppercasePressed)
            {
                buttonPressed = buttonPressed.ToUpper();
            }
            else
            {
                buttonPressed = buttonPressed.ToLower();
            }

            if (inputFieldEmailClicked)
            {
                if (buttonPressed.Equals("CANC")|| buttonPressed.Equals("canc"))
                {
                    inputFieldEmail.text = inputFieldEmail.text.Remove(inputFieldEmail.text.Length - 1);
                }
                else
                {
                    if (buttonPressed.Equals("ENTER") || buttonPressed.Equals("enter") || buttonPressed.Equals("EMPTY") || buttonPressed.Equals("empty") || buttonPressed.Equals("UPPER")||buttonPressed.Equals("upper"))
                    {
                    }
                    else
                    {
                        inputFieldEmail.text += buttonPressed;
                    }
                }

            }

            if (inputFieldPasswordClicked)
            {
                if (buttonPressed.Equals("CANC") || buttonPressed.Equals("canc"))
                {
                    inputFieldPassword.text = inputFieldPassword.text.Remove(inputFieldPassword.text.Length - 1);
                }
                else
                {
                    if (buttonPressed.Equals("ENTER") || buttonPressed.Equals("enter") || buttonPressed.Equals("EMPTY") || buttonPressed.Equals("empty") || buttonPressed.Equals("UPPER") || buttonPressed.Equals("upper"))
                    {
                    }
                    else
                    {
                        inputFieldPassword.text += buttonPressed;
                    }
                }
            }

        }


    }


}
