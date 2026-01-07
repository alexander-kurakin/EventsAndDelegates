using System.Collections.Generic;
using UnityEngine;

public class LogicRunner : MonoBehaviour
{
    private Wallet _wallet;
    private UIrowChanger _UIrowChanger;

    [SerializeField] private int _walletMaxValue = 9999;
    [SerializeField] private int _walletStartingValue = 0;
    
    [SerializeField] private Dictionary<CurrencyType, int> _configuredCurrency;
    [SerializeField] WalletView _walletView;

    [SerializeField] private Sprite _meatSprite;
    [SerializeField] private Sprite _moneySprite;
    [SerializeField] private Sprite _alcoholSprite;

    [SerializeField] private UIrowChanger _UIrowPrefab;
    [SerializeField] private Transform _UIObjectsParent;

    private void Awake()
    {
        _wallet = new Wallet(_walletMaxValue);
        _walletView.InitWallet(_wallet);

        _configuredCurrency = new Dictionary<CurrencyType, int>()
        {
            {CurrencyType.Meat, _walletStartingValue },
            {CurrencyType.Money, _walletStartingValue},
            {CurrencyType.Alcohol, _walletStartingValue },
        };

        _wallet.Init(_configuredCurrency);
    }

    private void Start()
    {
        SpawnUI();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
            _wallet.Add(CurrencyType.Meat, 100);

        if (Input.GetKeyDown(KeyCode.R))
            Debug.Log(_wallet.GetBalance(CurrencyType.Meat));
    }

    private void SpawnUI()
    {
        foreach (KeyValuePair<CurrencyType, int> currencyData in _configuredCurrency)
        {
            _UIrowChanger = Instantiate(_UIrowPrefab, _UIObjectsParent);

            Sprite spriteToSet;

            switch (currencyData.Key) {
                case CurrencyType.Meat:
                    spriteToSet = _meatSprite;
                    break;
                case CurrencyType.Alcohol:
                    spriteToSet = _alcoholSprite; 
                    break;
                case CurrencyType.Money:
                    spriteToSet = _moneySprite;
                    break;
                default:
                    spriteToSet = _moneySprite;
                    break;
            }

            _UIrowChanger.InitRow(spriteToSet, _walletStartingValue, _wallet, currencyData.Key);
        }
    }
}
