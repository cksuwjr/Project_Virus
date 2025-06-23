using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    private Button startBtn;

    private void Awake()
    {
        var btns = GameObject.Find("StartButton").GetComponentsInChildren<Button>();

        for (int i = 0; i < btns.Length; i++)
            btns[i].onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        LoadingSceneManager.SetNextScene("GameScene");
        SceneManager.LoadScene("LoadingScene");
    }
}
