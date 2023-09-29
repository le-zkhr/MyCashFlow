using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelLogic : MonoBehaviour
{
    [SerializeField] private Image[] _spins = new Image[3];
    [SerializeField] private Sprite _redIndicator;
    [SerializeField] private GameObject _drumCenter;
    [SerializeField] private float _startWheelSpeed = 20f, _interval = 0.5f;
    [SerializeField] private int _decreaser = 1;

    public int startAge = 0, salary = 0;
    public bool isWheelStopped;

    private Sprite _greenIndicator;
    private bool _canSpinWheel = true, _isWheelSpinning;
    private float _defaultWheelSpeed = 0;
    private int _spin = 0;

    private void Start()
    {
        _defaultWheelSpeed = _startWheelSpeed;
        _greenIndicator = _spins[0].GetComponent<Image>().sprite;
    }
    private void Update()
    {
        if(_isWheelSpinning)
            _drumCenter.transform.Rotate(0f, 0f, _startWheelSpeed * Time.deltaTime);

        if (_startWheelSpeed <= 0)
            ResetWheelSpeed();
    }

    IEnumerator LaunchTheWheel()
    {
        while(_startWheelSpeed > 0)
        {
            yield return new WaitForSeconds(_interval);

            _startWheelSpeed -= _decreaser;
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
        _startWheelSpeed = _defaultWheelSpeed;
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
            salary += 1000;

            for (int i = 0; i < _spins.Length; i++)
                _spins[i].GetComponent<Image>().sprite = _greenIndicator;
        }
    }
}
