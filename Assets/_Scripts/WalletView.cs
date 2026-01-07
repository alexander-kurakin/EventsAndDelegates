using System;
using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    private int _walletStartingValue;

    private Wallet _wallet;
    private UIrow _UIrow;
    private Dictionary<CurrencyType, int> _configuredCurrency;

    [SerializeField] private Sprite _meatSprite;
    [SerializeField] private Sprite _moneySprite;
    [SerializeField] private Sprite _alcoholSprite;

    [SerializeField] private UIrow _UIrowPrefab;
    [SerializeField] private Transform _UIObjectsParent;


    public void InitWallet(Wallet wallet, Dictionary<CurrencyType, int> configuredCurrency, int walletStartingValue)
    {
        _wallet = wallet;
        _configuredCurrency = new Dictionary<CurrencyType, int>(configuredCurrency);
        _walletStartingValue = walletStartingValue;
    }

    private void Start()
    {
        SpawnUI();
    }

    private void SpawnUI()
    {
        foreach (KeyValuePair<CurrencyType, int> currencyData in _configuredCurrency)
        {
            _UIrow = Instantiate(_UIrowPrefab, _UIObjectsParent);

            Sprite spriteToSet;

            switch (currencyData.Key)
            {
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

            _UIrow.InitRow(spriteToSet, _walletStartingValue, _wallet, currencyData.Key);
        }
    }

}
