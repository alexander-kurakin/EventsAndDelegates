using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<CurrencyType, int> Changed;

    private Dictionary<CurrencyType, int> _currencyData;

    public Wallet(int maxValue)
    {
        if (maxValue < 0)
        {
            Debug.LogError(nameof(maxValue));
            return;
        }

        MaxValue = maxValue;
        _currencyData = new Dictionary<CurrencyType, int>();
    }

    public int MaxValue { get; private set; }

    public void Init(Dictionary<CurrencyType, int> currencyData)
    { 
        _currencyData = new Dictionary<CurrencyType, int>(currencyData);        
    }

    public bool IsEnoughCapacity(CurrencyType type, int value) => _currencyData[type] + value <= MaxValue;

    public void Add(CurrencyType type, int value) 
    {
        if (value < 0 || IsEnoughCapacity(type,value) == false)
        {
            Debug.LogError(nameof(value));
            return;
        }

        _currencyData[type] += value;
        Changed?.Invoke(type, _currencyData[type]);
    }

    public int GetBalance(CurrencyType type)
    { 
        return _currencyData[type];
    }
}


