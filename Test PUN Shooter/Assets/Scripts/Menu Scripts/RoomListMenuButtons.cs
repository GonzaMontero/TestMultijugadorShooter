
using UnityEngine;
using UnityEngine.UI;

public class RoomListMenuButtons : MonoBehaviour
{
    [SerializeField] Button[] roomListButtons;

    void Start()
    {
        gameObject.SetActive(false);
    }
}
