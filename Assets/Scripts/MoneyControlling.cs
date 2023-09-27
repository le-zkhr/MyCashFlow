using UnityEngine;
using UnityEngine.UI;

public class MoneyControlling : MonoBehaviour
{
    [SerializeField] private GameObject _drum;

    private Text _moneyAmount;
    private int _salary = 0;

    private void Start()
    {
        _moneyAmount = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        _salary = _drum.GetComponent<WheelLogic>().salary;
        _moneyAmount.text = _salary.ToString();
    }
}
