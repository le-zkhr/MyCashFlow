using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelLogic : MonoBehaviour
{
    [SerializeField] private Image[] _spins = new Image[3];
    [SerializeField] private Sprite _redIndicator;
    [SerializeField] private GameObject _drumCenter;
    [SerializeField] private float _maxWheelSpeed = 500f;

    public int startAge = 0;
    public float moneyAmount = 0f;
    public bool isWheelStopped;

    private Sprite _greenIndicator;
    private bool _canSpinWheel = true, _isWheelSpinning;
    private float _wheelSpeed = 0f, _interval = 0.1f;
    private int _spin = 0, _decreaser = 5;

    private void Start()
    {
        SetRandomValues();
        _greenIndicator = _spins[0].GetComponent<Image>().sprite;
    }
    private void Update()
    {
        if (_isWheelSpinning)   
            _drumCenter.transform.Rotate(0f, 0f, _wheelSpeed * Time.deltaTime);

        if (_wheelSpeed <= 0)
            ResetWheelSpeed();
    }

    IEnumerator LaunchTheWheel()
    {
        while(_wheelSpeed > 0)
        {
            yield return new WaitForSeconds(_interval);

            _wheelSpeed -= _decreaser;
        }
    }

    public void SpinTheWheel()
    {
        if(_canSpinWheel)
        {
            Debug.Log("Wheel has been launched!");
            StartCoroutine("LaunchTheWheel");

            _isWheelSpinning = true;
            _canSpinWheel = false;
            isWheelStopped = false;
            startAge++;

            SpinsAndSalaryLogic();
        }         
    }
    private void ResetWheelSpeed()
    {
        SetRandomValues();
        _canSpinWheel = true;
        _isWheelSpinning = false;
        isWheelStopped = true;
    }
    private void SpinsAndSalaryLogic()
    {
        if (_spin < _spins.Length - 1)
        {
            _spins[_spin].GetComponent<Image>().sprite = _redIndicator;
            _spin++;
        }
        else
        {
            _spin = 0;
            moneyAmount += 1000;

            for (int i = 0; i < _spins.Length; i++)
                _spins[i].GetComponent<Image>().sprite = _greenIndicator;
        }
    }
    private void SetRandomValues()
    {
        while (true)
        {
            _wheelSpeed = Random.Range(200f, _maxWheelSpeed);
            if (_wheelSpeed % 10 == 0)
                break;
        }

        Debug.Log($"Speed {_wheelSpeed}, interval {_interval}, decreaser {_decreaser}");
    }
}
