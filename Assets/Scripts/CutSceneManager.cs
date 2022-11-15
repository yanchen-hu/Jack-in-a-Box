using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public enum CUTSCENE_TYPE
    {
        CUTSCENE_1,
        CUTSCENE_2,
        CUTSCENE_3,
        CUTSCENE_4,
    };
    public GameObject blur;
    public float TimeBetweenScenes;
    public Sprite[] cutScenes1;
    public Sprite[] cutScenes2;
    public Sprite[] cutScenes3;
    public Sprite[] cutScenes4;
    private int currentSceneIndex = 0;
    private Sprite[] spritesToPlay;

    // Start is called before the first frame update
    void Start()
    {
        blur.SetActive(false);
        this.GetComponent<Image>().enabled = false;
        //PlayCutScene(CUTSCENE_TYPE.CUTSCENE_1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeSceneIndex(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentSceneIndex++;
        if(currentSceneIndex<spritesToPlay.Length)
        {
            this.GetComponent<Image>().sprite = spritesToPlay[currentSceneIndex];
            StartCoroutine(ChangeSceneIndex(TimeBetweenScenes));
        }
        else
        {
            this.GetComponent<Image>().enabled = false;
            blur.SetActive(false);
        }
        
    }

    public void PlayCutScene(CUTSCENE_TYPE type)
    {
        if (type == CUTSCENE_TYPE.CUTSCENE_1) spritesToPlay = cutScenes1;
        else if(type == CUTSCENE_TYPE.CUTSCENE_2) spritesToPlay = cutScenes2;
        else if (type == CUTSCENE_TYPE.CUTSCENE_3) spritesToPlay = cutScenes3;
        else if (type == CUTSCENE_TYPE.CUTSCENE_4) spritesToPlay = cutScenes4;
        this.GetComponent<Image>().enabled = true;
        this.GetComponent<Image>().sprite = spritesToPlay[0];
        currentSceneIndex = 0;
        blur.SetActive(true);
        StartCoroutine(ChangeSceneIndex(TimeBetweenScenes));
    }
}
