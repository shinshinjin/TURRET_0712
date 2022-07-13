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
        // ������ ���� �Ǿ�����
        if (_isOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void End()
    {
        // Ÿ�̸� ����
        TimertextUI.IsOn = false;
        // ������ ����
        //int bestTime = (int)TimertextUI.SurvivalTime;
        int savedBestTime = PlayerPrefs.GetInt("BestTime", 0);
        int bestTime = Math.Max((int)TimertextUI.SurvivalTime, savedBestTime);
        PlayerPrefs.SetInt("BestTime", bestTime);

        if (bestTime < savedBestTime)
        {
            bestTime = savedBestTime;
        }
        PlayerPrefs.SetInt("BestTime", bestTime);

        // GameOverUI�� ����
        GameOverUI.Activate(bestTime);

        _isOver = true;
    }

}
