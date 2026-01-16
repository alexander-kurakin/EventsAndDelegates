using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIrow : MonoBehaviour
{
    private int _currencyIncrement;
    private int _currencyDecrement;

    private Wallet _wallet;
    private CurrencyType _currencyType;

    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _removeButton;

    public void InitRow(Sprite spriteToSet, int valueToSet, Wallet wallet, CurrencyType currencyType, int currencyIncrement, int currencyDecrement)
    {
        _iconImage.sprite = spriteToSet;
        _currencyText.text = valueToSet.ToString();

        _currencyType = currencyType;
        _wallet = wallet;

        _currencyIncrement = currencyIncrement;
        _currencyDecrement = currencyDecrement;

        _wallet.Changed += OnChanged;

        _addButton.onClick.AddListener(OnAddClick);
        _removeButton.onClick.AddListener(OnRemoveClick);
    }

    private void OnRemoveClick()
    {
        _wallet.Remove(_currencyType, _currencyDecrement);
    }

    private void OnAddClick()
    {
        _wallet.Add(_currencyType, _currencyIncrement);
    }

    private void OnDestroy()
    {
        _wallet.Changed -= OnChanged;
        _addButton.onClick.AddListener(OnAddClick);
        _removeButton.onClick.AddListener(OnRemoveClick);
    }

    private void OnChanged(CurrencyType currencyTypeOnChanged, int valueToSet)
    {
        if (currencyTypeOnChanged == _currencyType)
            _currencyText.text = valueToSet.ToString();
    }
}
