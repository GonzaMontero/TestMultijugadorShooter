using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Transform spawnPoint = SpawnManager.Instance.GetSpawnPoint();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player Controller"),spawnPoint.position,spawnPoint.rotation);
    }
}
