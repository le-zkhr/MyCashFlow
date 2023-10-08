using UnityEngine;
using UnityEngine.UI;

public class CardsLogic : MonoBehaviour
{
    [SerializeField] private GameObject _spinLogicObject, _card;
    [SerializeField] private Text _buyingCostData, _buyingAmountData, _sellingCostData, _sellingAmountData, _cardsAmountData, _moneyAmountText,
        _primaryBuyPriceText, _primarySellPriceFromText, _primarySellPriceToText;
    [SerializeField] private int _primaryBuyPrice, _primarySellPriceFrom, _primarySellPriceTo;
    [SerializeField] private bool _hasRange = true;

    private int _amountToBuy, _amountForSell, _cardsAmount;
    private float _buyingCost, _sellingCost;

    private void Start()
    {
        SetValues(_primaryBuyPriceText, _primaryBuyPrice);

        if (_hasRange)
        {
            SetValues(_primarySellPriceFromText, _primarySellPriceFrom);
            SetValues(_primarySellPriceToText, _primarySellPriceTo);
        }
    }

    public void CloseTheCard()
    {
        _card.SetActive(false);

        ResetBuyingValues();
        ResetSellingValues();
    }

    public void IncreaseBuyAmount()
    {
        float money = _spinLogicObject.GetComponent<WheelLogic>().moneyAmount;

        if (_buyingCost <= money)
        {
            _amountToBuy += 1;
            _buyingCost += _primaryBuyPrice;

            if (_buyingCost > money)
            { _amountToBuy -= 1; _buyingCost -= _primaryBuyPrice; }

            _buyingAmountData.text = _amountToBuy.ToString();
            _buyingCostData.text = _buyingCost.ToString();
        }
        AddBuyPricePostfixes();
    }
    public void DecreaseBuyAmount()
    {
        if (_buyingCost > 0)
        {
            _amountToBuy -= 1;
            _buyingCost -= _primaryBuyPrice;

            _buyingAmountData.text = _amountToBuy.ToString();
            _buyingCostData.text = _buyingCost.ToString();
        }
        AddBuyPricePostfixes();
    }
    public void Buy()
    {
        _spinLogicObject.GetComponent<WheelLogic>().moneyAmount -= _buyingCost;

        _cardsAmount += _amountToBuy;
        _cardsAmountData.text = _cardsAmount.ToString();

        ResetBuyingValues();
    }

    public void IncreaseSellAmount()
    {
        if(_amountForSell < _cardsAmount & _hasRange)
        {
            _amountForSell += 1;
            _sellingCost += _primarySellPriceFrom;

            _sellingAmountData.text = _amountForSell.ToString();
            _sellingCostData.text = _sellingCost.ToString();

            AddSellPricePostfixes();
        }
    }
    public void DecreaseSellAmount()
    {
        if (_amountForSell > 0 & _hasRange)
        {
            _amountForSell -= 1;
            _sellingCost -= _primarySellPriceFrom;

            _sellingAmountData.text = _amountForSell.ToString();
            _sellingCostData.text = _sellingCost.ToString();

            AddSellPricePostfixes();
        }
    }
    public void Sell()
    {
        if (_hasRange)
        {
            _spinLogicObject.GetComponent<WheelLogic>().moneyAmount += _sellingCost;

            _cardsAmount -= _amountForSell;
            _cardsAmountData.text = _cardsAmount.ToString();

            ResetSellingValues();
        }
    }

    private void SetValues(Text priceText, int price)
    {
        if (price >= 1000)
            priceText.text = (price / 1000.0).ToString() + 'K';
        else if (price >= 1000000)
            priceText.text = (price / 1000000.0).ToString() + 'M';
        else
            priceText.text = price.ToString();
    }

    private void AddBuyPricePostfixes()
    {
        if (_buyingCost >= 1000)
            _buyingCostData.text = (_buyingCost / 1000.0).ToString() + 'K';
        else if (_buyingCost >= 1000000)
            _buyingCostData.text = (_buyingCost / 1000000.0).ToString() + 'M';
        else
            _buyingCostData.text = _buyingCost.ToString();
    }
    private void AddSellPricePostfixes()
    {
        if (_sellingCost >= 1000)
            _sellingCostData.text = (_sellingCost / 1000.0).ToString() + 'K';
        else if (_sellingCost >= 1000000)
            _sellingCostData.text = (_sellingCost / 1000000.0).ToString() + 'M';
        else
            _sellingCostData.text = _sellingCost.ToString();
    }

    private void ResetBuyingValues()
    {
        _amountToBuy = 0;
        _buyingCost = 0;
        _buyingAmountData.text = _amountToBuy.ToString();
        _buyingCostData.text = _buyingCost.ToString();
    }
    private void ResetSellingValues()
    {
        _amountForSell = 0;
        _sellingCost = 0;
        _sellingAmountData.text = _amountForSell.ToString();
        _sellingCostData.text = _sellingCost.ToString();
    }
}