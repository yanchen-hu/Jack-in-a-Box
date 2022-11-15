using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosswordManager : MonoBehaviour
{
    Manager.MINI_GAME_TYPE type = Manager.MINI_GAME_TYPE.CROSSWORD;
    public InputField[] Line1;
    public InputField[] Line2;
    public InputField[] Line3;
    public InputField[] Line4;
    private string[] puzzleWords;
    private bool[] WordsSuccess;
    private bool game_won = false;
    // Start is called before the first frame update
    void Start()
    {
        puzzleWords = new string[4];
        puzzleWords[0] = "truman";
        puzzleWords[1] = "loop";
        puzzleWords[2] = "shining";
        puzzleWords[3] = "groundhog";
    }

    private void Awake()
    {
        WordsSuccess = new bool[4];
    }

    void HandleOneLineSuccess(int index, InputField[] line)
    {
        WordsSuccess[index] = true;
        for(int i = 0;i< line.Length;i++)
        {
            line[i].interactable = false;
        }
        print("success");
    }

    bool CheckWord()
    {
        bool isAllCorrect = true;
        for(int m = 0;m<4;m++)
        {
            if (WordsSuccess[m]) continue;

            InputField[] fieldsToCheck;
            if (m == 0) fieldsToCheck = Line1;
            else if (m == 1) fieldsToCheck = Line2;
            else if (m == 2) fieldsToCheck = Line3;
            else fieldsToCheck = Line4;

            bool isSuccess = true;
            for (int i = 0; i < puzzleWords[m].Length; i++)
            {
                isSuccess = isSuccess && (puzzleWords[m][i].ToString() == fieldsToCheck[i].text);
            }

            if (isSuccess)
            {
                HandleOneLineSuccess(m, fieldsToCheck);
            }
            else isAllCorrect = false;
        }
        return isAllCorrect;

    }
    // Update is called once per frame
    void Update()
    {
        if(!game_won && CheckWord())
        {
            print("all success");
            Manager.HandleMiniGameSuccess(type);
            game_won = true;
            this.gameObject.SetActive(false);
        }
    }


}

