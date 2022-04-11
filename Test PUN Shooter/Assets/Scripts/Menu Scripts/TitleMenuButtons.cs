using UnityEngine;
using UnityEngine.UI;

public class TitleMenuButtons : MonoBehaviour
{
    [SerializeField] Button[] mainMenuButtons;

    void Start()
    {
        gameObject.SetActive(false);
    }
}
