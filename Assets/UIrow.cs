using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIrow : MonoBehaviour
{
    private Wallet _wallet;
    private CurrencyType _currencyType;

    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _currencyText;

    private void Awake()
    {
        
    }
    public void InitRow(Sprite spriteToSet, int valueToSet, Wallet wallet, CurrencyType currencyType)
    {
        _iconImage.sprite = spriteToSet;
        _currencyText.text = valueToSet.ToString();

        _currencyType = currencyType;
        _wallet = wallet;

        _wallet.Changed += OnChanged;

    }

    private void OnDestroy()
    {
        _wallet.Changed -= OnChanged;
    }

    private void OnChanged(CurrencyType currencyType, int valueToSet)
    {
        if (currencyType == _currencyType)
            _currencyText.text = valueToSet.ToString();
    }
}
