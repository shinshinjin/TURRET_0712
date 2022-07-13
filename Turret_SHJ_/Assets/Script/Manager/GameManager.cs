using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TimerText TimertextUI;
    public GameOverUI GameOverUI;

    private bool _isOver;

    void Update()
    {
        // 게임이 종료 되었따면
        if (_isOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void End()
    {
        // 타이머 종료
        TimertextUI.IsOn = false;
        // 데이터 저장
        //int bestTime = (int)TimertextUI.SurvivalTime;
        int savedBestTime = PlayerPrefs.GetInt("BestTime", 0);
        int bestTime = Math.Max((int)TimertextUI.SurvivalTime, savedBestTime);
        PlayerPrefs.SetInt("BestTime", bestTime);

        if (bestTime < savedBestTime)
        {
            bestTime = savedBestTime;
        }
        PlayerPrefs.SetInt("BestTime", bestTime);

        // GameOverUI에 갱신
        GameOverUI.Activate(bestTime);

        _isOver = true;
    }

}
