using System.Collections.Generic;
using UnityEngine;

public class LogicRunner : MonoBehaviour
{
    private Wallet _wallet;
    private Timer _timer;
    private Dictionary<CurrencyType, int> _configuredCurrency;

    [SerializeField] private int _walletMaxValue = 9999;
    [SerializeField] private int _walletStartingValue = 0;

    [SerializeField] private float _defaultTimerValue = 10f;
    
    [SerializeField] private WalletView _walletView;
    [SerializeField] private TimerView _timerView;

    private void Awake()
    {
        _configuredCurrency = new Dictionary<CurrencyType, int>()
        {
            {CurrencyType.Meat, _walletStartingValue },
            {CurrencyType.Money, _walletStartingValue},
            {CurrencyType.Alcohol, _walletStartingValue },
        };

        _wallet = new Wallet(_walletMaxValue);
        _wallet.Init(_configuredCurrency);

        _walletView.InitWallet(_wallet, _configuredCurrency, _walletStartingValue);

        _timer = new Timer(this, _defaultTimerValue);
        _timerView.InitTimer(_timer);
    }
}