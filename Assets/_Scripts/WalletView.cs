using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    private int _walletStartingValue;

    private Wallet _wallet;
    private UIrow _UIrow;
    private Dictionary<CurrencyType, int> _configuredCurrency;

    [SerializeField] private Sprite _meatSprite;
    [SerializeField] private int _meatIncrement = 10;
    [SerializeField] private int _meatDecrement = 25;

    [SerializeField] private Sprite _moneySprite;
    [SerializeField] private int _moneyIncrement = 50;
    [SerializeField] private int _moneyDecrement = 75;

    [SerializeField] private Sprite _alcoholSprite;
    [SerializeField] private int _alcoholIncrement = 100;
    [SerializeField] private int _alcoholDecrement = 125;

    [SerializeField] private UIrow _UIrowPrefab;
    [SerializeField] private Transform _UIObjectsParent;

    private void Start()
    {
        SpawnUI();
    }
    public void InitWallet(Wallet wallet, Dictionary<CurrencyType, int> configuredCurrency, int walletStartingValue)
    {
        _wallet = wallet;
        _configuredCurrency = new Dictionary<CurrencyType, int>(configuredCurrency);
        _walletStartingValue = walletStartingValue;
    }


    private void SpawnUI()
    {
        foreach (KeyValuePair<CurrencyType, int> currencyData in _configuredCurrency)
        {
            _UIrow = Instantiate(_UIrowPrefab, _UIObjectsParent);

            Sprite spriteToSet;
            int incrementToSet;
            int decrementToSet;

            switch (currencyData.Key)
            {
                case CurrencyType.Meat:
                    spriteToSet = _meatSprite;
                    incrementToSet = _meatIncrement;
                    decrementToSet = _meatDecrement;
                    break;
                case CurrencyType.Alcohol:
                    spriteToSet = _alcoholSprite;
                    incrementToSet = _alcoholIncrement;
                    decrementToSet = _alcoholDecrement;
                    break;
                case CurrencyType.Money:
                    spriteToSet = _moneySprite;
                    incrementToSet = _moneyIncrement;
                    decrementToSet = _moneyDecrement;
                    break;
                default:
                    spriteToSet = _moneySprite;
                    incrementToSet = _moneyIncrement;
                    decrementToSet = _moneyDecrement;
                    break;
            }

            _UIrow.InitRow(spriteToSet, _walletStartingValue, _wallet, currencyData.Key, incrementToSet, decrementToSet);
        }
    }

}
