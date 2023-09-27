using UnityEngine;
using UnityEngine.UI;

public class AgeAddiction : MonoBehaviour
{
    [SerializeField] private GameObject _drum;

    private Text _ageData;
    private int _age = 0;

    private void Start()
    {
        _ageData = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        _age = _drum.GetComponent<WheelLogic>().startAge;
        _ageData.text = _age.ToString();
    }
}
