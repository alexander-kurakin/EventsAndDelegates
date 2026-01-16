using System;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    private Timer _timer;
    private TimerRow _timerRow;

    [SerializeField] private TimerRow _timerRowPrefab;
    [SerializeField] private Transform _timerObjectsParent;

    public void InitTimer(Timer timer)
    {
        _timer = timer;
        SpawnUI();
    }

    private void SpawnUI()
    {
        _timerRow = Instantiate(_timerRowPrefab, _timerObjectsParent);
        _timerRow.InitRow(_timer);
    }
}
