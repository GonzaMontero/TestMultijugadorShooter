using UnityEngine;
using UnityEngine.UI;

public class CreateRoomMenuButtons : MonoBehaviour
{
    [SerializeField] Button[] createRoomButtons;

    void Start()
    {
        gameObject.SetActive(false);
    }
}
