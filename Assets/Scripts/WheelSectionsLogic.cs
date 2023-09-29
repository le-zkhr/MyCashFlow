using UnityEngine;

public class WheelSectionsLogic : MonoBehaviour
{
    [SerializeField] private GameObject _drumCenter;
    private bool _isWheelStopped;

    private void Update()
    {
        _isWheelStopped = _drumCenter.GetComponent<WheelLogic>().isWheelStopped;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isWheelStopped)
        {
            switch (collision.tag)
            {
                case ("Orange Section"): 
                    Debug.Log("Orange!");
                    break;

                case ("Pink Section"):
                    Debug.Log("Pink!");
                    break;

                case ("Blue Section"):
                    Debug.Log("Blue!");
                    break;

                case ("Cian Section"):
                    Debug.Log("Cian!");
                    break;

                case ("Yellow Section"):
                    Debug.Log("Yellow!");
                    break;

                case ("Green Section"):
                    Debug.Log("Green!");
                    break;
            }
        }
    }
}
