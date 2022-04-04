using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject graphicsField;

    private void Awake()
    {
        graphicsField.SetActive(false);
    }
}
