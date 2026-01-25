using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerRowControl : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private TMP_Text _timerText;

    private Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
        _timer.ElapsedTimeChanged += OnElapsedTimeChanged;

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

    private void OnElapsedTimeChanged(float elapsedTime)
    {
        _timerText.text = elapsedTime.ToString("0.00");
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
}
