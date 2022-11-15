using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    Manager.MINI_GAME_TYPE type = Manager.MINI_GAME_TYPE.PASSWORD;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleGameSuccess()
    {
        Manager.HandleMiniGameSuccess(type);
        this.gameObject.SetActive(false);
    }
}
