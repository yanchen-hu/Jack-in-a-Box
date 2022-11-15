using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewriter : MonoBehaviour
{
    string Input;
    string Sentence;
    public Text someText;
    void Start()
    {
        Input = "";
        Sentence = Input;
        
    }

    // Update is called once per frame
    void Update()
    {
        Sentence = Input;
        someText.text = Sentence;
    }
    public void HandleDClicked()
    {
        Input += "d";
    }
    public void HandleUClicked()
    {
        Input += "u";
    }
    public void HandleLClicked()
    { 
        Input += "l";
    }
    public void HandleBClicked()
    {
        Input += "b";
    }
    public void HandleOClicked()
    {
        Input += "o";
    }
    public void HandleYClicked()
    {
        Input += "y";
    }
    public void HandleSpaceClicked()
    {
        Input += " ";
    }
    public void HandleBackClicked()
    {
        Input = Input.Remove(Input.Length - 1,1);
    }
    public void HandleEnterClicked()
    {
        if (Input == "dull boy")
        {
            this.GetComponent<TypewriterManager>().HandleGameSuccess();
            //GameObject obj = gameobject.findGameobjectWithTag();
            //obj.GetComponent<>;

        }
        else
        {
            //显示Try Again一段时间后清空？
            print("Try Again.");
        }
    }
}
