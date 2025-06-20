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
        if (GameObject.Find("StartButton").TryGetComponent<Button>(out startBtn))
            startBtn.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        LoadingSceneManager.SetNextScene("GameScene");
        SceneManager.LoadScene("LoadingScene");
    }
}
