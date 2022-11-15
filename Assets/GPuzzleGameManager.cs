using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPuzzleGameManager : MonoBehaviour
{
    Manager.MINI_GAME_TYPE type = Manager.MINI_GAME_TYPE.G_PUZZLE;
    public movepiece[] Pieces;
    private bool isSuccess = false;
    private bool coroutineStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator WaitAndClose()
    {
        coroutineStarted = true;
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSuccess && !coroutineStarted)
        {
            StartCoroutine(WaitAndClose());
        }

        if(!isSuccess)
        {
            bool win = true;
            for (int i = 0; i < Pieces.Length; i++)
            {
                if (Pieces[i].pieceStatus != movepiece.PIECE_STATUS.SUCCESS)
                {
                    win = false;
                }
            }
            if (win)
            {
                isSuccess = true;
                Manager.HandleMiniGameSuccess(type);
                this.gameObject.SetActive(false);
            }
        }
       
    }
}
