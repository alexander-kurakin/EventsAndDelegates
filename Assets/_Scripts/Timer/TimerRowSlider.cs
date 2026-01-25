using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRowSlider : MonoBehaviour
{
    [SerializeField] private Slider _timerSlider;
    private Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
        _timerSlider.maxValue = _timer.TimerValue;
        _timerSlider.value = _timerSlider.maxValue;

        _timer.ElapsedTimeChanged += OnElapsedTimeChanged;
    }

    private void OnElapsedTimeChanged(float elapsedTime)
    {
        _timerSlider.value = elapsedTime;
    }

    private void OnDestroy()
    {
        _timer.ElapsedTimeChanged -= OnElapsedTimeChanged;
    }
}
