using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerRow : MonoBehaviour
{
    private Timer _timer;
    private List<GridElement> _gridElements = new();

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _stopButton;

    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private Transform _timerGridParent;
    [SerializeField] private GridElement _timerGridElementPrefab;

    private void Awake()
    {
        _startButton.onClick.AddListener(OnStartClick);
        _pauseButton.onClick.AddListener(OnPauseClick);
        _stopButton.onClick.AddListener(OnStopClick);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(OnStartClick);
        _pauseButton.onClick.RemoveListener(OnPauseClick);
        _stopButton.onClick.RemoveListener(OnStopClick);

        _timer.ElapsedTimeChanged -= OnElapsedTimeChanged;
        
    }

    private void OnStartClick()
    {
        _timer.Start();
    }

    private void OnPauseClick()
    {
        _timer.Pause();
    }

    private void OnStopClick()
    {
        _timer.Stop();
    }

    public void InitRow(Timer timer)
    {
        _timer = timer;
        _timer.ElapsedTimeChanged += OnElapsedTimeChanged;

        _timerSlider.maxValue = _timer.TimerValue;
        _timerSlider.value = _timerSlider.maxValue;

        SpawnGrid(_timer.TimerValue);
    }

    private void OnElapsedTimeChanged(float elapsedTime)
    {
        _timerSlider.value = elapsedTime;
        _timerText.text = elapsedTime.ToString("0.00");
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
