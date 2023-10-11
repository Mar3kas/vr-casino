using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadInGameScene()
    {
        SceneManager.LoadScene("InGame", LoadSceneMode.Single);
    }
}
