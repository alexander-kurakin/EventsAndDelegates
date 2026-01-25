using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRowGrid : MonoBehaviour
{
    [SerializeField] private Transform _timerGridParent;
    [SerializeField] private GridElement _timerGridElementPrefab;

    private Timer _timer;
    private List<GridElement> _gridElements = new();

    public void Init(Timer timer)
    {
        _timer = timer;
        _timer.ElapsedTimeChanged += OnElapsedTimeChanged;

        SpawnGrid(_timer.TimerValue);
    }

    private void OnElapsedTimeChanged(float elapsedTime)
    {
        UpdateGrid(elapsedTime);
    }

    private void SpawnGrid(float timerValue)
    {
        int secondsCount = (int)timerValue;
        GridElement gridElement;

        for (int i = 0; i < secondsCount; i++)
        {
            gridElement = Instantiate(_timerGridElementPrefab, _timerGridParent);
            _gridElements.Add(gridElement);
        }
    }

    private void UpdateGrid(float elapsedTime)
    {
        int countOfSeconds = (int)elapsedTime;
        int tempCounter = 0;

        foreach (GridElement gridElement in _gridElements)
        {
            tempCounter++;

            if (tempCounter <= countOfSeconds)
                gridElement.gameObject.SetActive(true);
            else
                gridElement.gameObject.SetActive(false);
        }

    }
}
