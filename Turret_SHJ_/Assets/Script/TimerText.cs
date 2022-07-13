using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public float SurvivalTime { get; private set; }
    public bool IsOn { get; set; }

    private TextMeshProUGUI _ui;
    private float _elapsedTime;

    void Start()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        _ui.text = $"시간 : {(int)SurvivalTime}초";
        IsOn = true;
    }

    void Update()
    {
        if (IsOn)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= 1f)
            {
                SurvivalTime += _elapsedTime;
                _elapsedTime = 0f;
                _ui.text = $"시간 : {(int)SurvivalTime}초";
            }
        }
    }
}
