using UnityEngine;

public class WheelSectionsLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] _realEstateCards, _stockCards, _cryptocurrencyCards, _startupCards, _contributionCards;
    [SerializeField] private GameObject _drumCenter;
    [SerializeField] private float _cardAppearingCooldown = 1f;

    private int card;
    private bool _isWheelStopped, _isValueGot;

    private void Update()
    {
        _isWheelStopped = _drumCenter.GetComponent<WheelLogic>().isWheelStopped;
        if (Input.GetKeyDown(KeyCode.J))
            ThrowRealEstateCards();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isWheelStopped)
        {
            switch (collision.tag)
            {
                case "Orange Section":
                    Invoke("ThrowRealEstateCards", _cardAppearingCooldown);
                    break;

                case "Pink Section":
                    Debug.Log("Pink!");
                    break;

                case ("Blue Section"):
                    Invoke("ThrowContributionCard", _cardAppearingCooldown);
                    break;

                case ("Cian Section"):
                    Invoke("ThrowStartupCard", _cardAppearingCooldown);
                    break;

                case ("Yellow Section"):
                    Invoke("ThrowCryptocurrencyCard", _cardAppearingCooldown);
                    break;

                case ("Green Section"):
                    Invoke("ThrowStockCards", _cardAppearingCooldown);
                    break;
            }
        }
        else
            _isValueGot = false;
    }

    private void ThrowRealEstateCards()
    {
        if (!_isValueGot)
        {
            card = Random.Range(0, _realEstateCards.Length);
            _realEstateCards[card].SetActive(true);
            Debug.Log(card);
        }
        _isValueGot = true;
    }
    private void ThrowStockCards()
    {
        if (!_isValueGot)
        {
            card = Random.Range(0, _stockCards.Length);
            _stockCards[card].SetActive(true);
            Debug.Log(card);
        }
        _isValueGot = true;
    }
    private void ThrowCryptocurrencyCard()
    {
        if (!_isValueGot)
        {
            card = Random.Range(0, _cryptocurrencyCards.Length);
            _cryptocurrencyCards[card].SetActive(true);
            Debug.Log(card);
        }
        _isValueGot = true;
    }
    private void ThrowStartupCard()
    {
        if (!_isValueGot)
        {
            card = Random.Range(0, _startupCards.Length);
            _startupCards[card].SetActive(true);
            Debug.Log(card);
        }
        _isValueGot = true;
    }
    private void ThrowContributionCard()
    {
        if (!_isValueGot)
        {
            card = Random.Range(0, _contributionCards.Length);
            _contributionCards[card].SetActive(true);
            Debug.Log(card);
        }
        _isValueGot = true;
    }
}