using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardInput : MonoBehaviour
{
    public string currentInput;
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        currentInput = "";
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = currentInput;
    }
    public void HandleNumberOneClicked()
    {
        currentInput += "1";
    }
    public void HandleNumberTwoClicked()
    {
        currentInput += "2";
    }
    public void HandleNumberThreeClicked()
    {
        currentInput += "3";
    }
    public void HandleNumberFourClicked()
    {
        currentInput += "4";
    }
    public void HandleNumberFiveClicked()
    {
        currentInput += "5";
    }
    public void HandleNumberSixClicked()
    {
        currentInput += "6";
    }
    public void HandleNumberSevenClicked()
    {
        currentInput += "7";
    }
    public void HandleNumberEightClicked()
    {
        currentInput += "8";
    }
    public void HandleNumberNineClicked()
    {
        currentInput += "9";
    }
    public void HandleCancelClicked()
    {
        currentInput = "";
    }

    public void HandleEnterClicked()
    {
        if(currentInput == Manager.GameEndTime)
        {
            currentInput = "Success!";
            this.GetComponent<PasswordManager>().HandleGameSuccess();
            //GameObject obj = gameobject.findGameobjectWithTag();
            //obj.GetComponent<>;
            
        }
        else
        {
            //显示Try Again一段时间后清空？
            print("Try Again.");
            currentInput = "";
        }
    }
}
