using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIrow : MonoBehaviour
{
    private const string AddButtonType = "Add";
    private const string RemoveButtonType = "Remove";

    private Wallet _wallet;
    private CurrencyType _currencyType;

    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private CurrencyButton _currencyAddButton;
    [SerializeField] private CurrencyButton _currencyRemoveButton;

    public void InitRow(Sprite spriteToSet, int valueToSet, Wallet wallet, CurrencyType currencyType, int currencyIncrement, int currencyDecrement)
    {
        _iconImage.sprite = spriteToSet;
        _currencyText.text = valueToSet.ToString();

        _currencyType = currencyType;
        _wallet = wallet;

        _wallet.Changed += OnChanged;

        _currencyAddButton.SetButton(_currencyType, currencyIncrement, currencyDecrement, wallet, AddButtonType);
        _currencyRemoveButton.SetButton(_currencyType, currencyIncrement, currencyDecrement, wallet, RemoveButtonType);
    }

    private void OnDestroy()
    {
        _wallet.Changed -= OnChanged;
    }

    private void OnChanged(CurrencyType currencyTypeOnChanged, int valueToSet)
    {
        if (currencyTypeOnChanged == _currencyType)
            _currencyText.text = valueToSet.ToString();
    }
}
