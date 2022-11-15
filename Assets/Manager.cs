using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    static public CutSceneManager cutSceneMng;
    static public int NumOfGameCompleted;
    static public string GameEndTime;
    public Text text;
    private bool HasThreeGamesCompleted;
    public enum MINI_GAME_TYPE
    {
        PASSWORD,
        G_PUZZLE,
        TYPEWRITER,
        CROSSWORD,
    }

    // Start is called before the first frame update
    void Start()
    {
        NumOfGameCompleted = 0;
        HasThreeGamesCompleted = false;
        cutSceneMng = GameObject.FindGameObjectWithTag("CUTSCENEMANAGER").GetComponent<CutSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NumOfGameCompleted == 3 &&!HasThreeGamesCompleted)
        {
            HasThreeGamesCompleted = true;
            DateTime time = DateTime.Now;
            string currentTime = string.Format("{0:D}:{1:D}", time.Hour, time.Minute);
            text.gameObject.SetActive(true);
            text.text = "Congrats! This game ended at " + currentTime;
            GameEndTime = string.Format("{0:D}{1:D}", time.Hour, time.Minute);
        }

    }
    static public void HandleMiniGameSuccess(MINI_GAME_TYPE type)
    {
        //if(type == MINI_GAME_TYPE.PASSWORD)
        //{
        //
        //}
        //else if(type == MINI_GAME_TYPE.G_PUZZLE)
        //{
        //
        //}

        switch(type)
        {
            case MINI_GAME_TYPE.PASSWORD:
              //  cutSceneMng.PlayCutScene(CutSceneManager.CUTSCENE_TYPE.CUTSCENE_4);
                print("PASSWORD GAME SUCCESS!");
                break;
            case MINI_GAME_TYPE.G_PUZZLE:
                cutSceneMng.PlayCutScene(CutSceneManager.CUTSCENE_TYPE.CUTSCENE_2);
                print("G PUZZLE GAME SUCCESS!");
                break;
            case MINI_GAME_TYPE.TYPEWRITER:
                cutSceneMng.PlayCutScene(CutSceneManager.CUTSCENE_TYPE.CUTSCENE_3);
                print("TYPEWRITER GAME SUCCESS!");
                break;
            case MINI_GAME_TYPE.CROSSWORD:
                cutSceneMng.PlayCutScene(CutSceneManager.CUTSCENE_TYPE.CUTSCENE_1);
                print("TYPEWRITER GAME SUCCESS!");
                break;
            default:
                break;
        }
        NumOfGameCompleted++;
    }
}
