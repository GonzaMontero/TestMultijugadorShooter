using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsernameChange : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;

    public void OnUsernameInputValueChange()
    {
        PhotonNetwork.NickName = usernameInput.text;
    }
}
