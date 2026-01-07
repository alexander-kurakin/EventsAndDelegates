using System.Collections.Generic;
using UnityEngine;

public class LogicRunner : MonoBehaviour
{
    private Wallet _wallet;
    private Dictionary<CurrencyType, int> _configuredCurrency;

    [SerializeField] private int _walletMaxValue = 9999;
    [SerializeField] private int _walletStartingValue = 0;
    
    [SerializeField] private WalletView _walletView;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _wallet.Add(CurrencyType.Meat, 100);

        if (Input.GetKeyDown(KeyCode.R))
            Debug.Log(_wallet.GetBalance(CurrencyType.Meat));
    }


}
