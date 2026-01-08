using UnityEngine;
using UnityEngine.UI;

public class CurrencyButton : MonoBehaviour
{
    private const string AddButtonType = "Add";
    private const string RemoveButtonType = "Remove";

    private Button _button;
    private CurrencyType _currencyType;
    private Wallet _wallet;

    private int _incrementBy;
    private int _decrementBy;
    private string _buttonType;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void SetButton(CurrencyType currencyType, int incrementBy, int decrementBy, Wallet wallet, string buttonType)
    { 
        _currencyType = currencyType;
        _incrementBy = incrementBy;
        _decrementBy = decrementBy;
        _buttonType = buttonType;

        _wallet = wallet;
    }

    private void OnButtonClick()
    {
        if (_buttonType == AddButtonType)
            _wallet.Add(_currencyType, _incrementBy);
        else if (_buttonType == RemoveButtonType)
            _wallet.Remove(_currencyType, _decrementBy);
    }
}
