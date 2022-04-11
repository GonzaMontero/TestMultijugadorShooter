using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class UsernameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView playerPV;
    [SerializeField] TMP_Text text;

    void Start()
    {
        text.text = playerPV.Owner.NickName;
    }
}
