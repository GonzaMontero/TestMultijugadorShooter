using UnityEngine;
using UnityEngine.UI;

public class RoomMenuButtons : MonoBehaviour
{
    [SerializeField] Button[] roomMenuButtons;

    void Start()
    {
        gameObject.SetActive(false);
    }
}
