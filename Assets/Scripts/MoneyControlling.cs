using UnityEngine;
using UnityEngine.UI;

public class MoneyControlling : MonoBehaviour
{
    [SerializeField] private GameObject _drumCenter;
    
    private float _moneyAmount;
    private Text _moneyAmountText;

    private void Start()
    {
        _moneyAmountText = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        _moneyAmount = _drumCenter.GetComponent<WheelLogic>().moneyAmount;
        if(_moneyAmount >= 1000)
            _moneyAmountText.text = (_moneyAmount / 1000.0).ToString() + 'K';
        else if (_moneyAmount >= 1000000)
            _moneyAmountText.text = (_moneyAmount / 1000000.0).ToString() + 'M';
        else
            _moneyAmountText.text = _moneyAmount.ToString();

    }
}
