using UnityEngine;
using UnityEngine.UI;

public class RoomFailedMenuButtons : MonoBehaviour
{
    [SerializeField] Button roomFailedButtons;

    void Start()
    {       
        gameObject.SetActive(false);       
    }
}
