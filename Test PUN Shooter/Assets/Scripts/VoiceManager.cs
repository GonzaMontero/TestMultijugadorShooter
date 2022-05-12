using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;
using Photon.Pun;
using System;

public class VoiceManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string appID = "bc0a3049b7724b22b52b1226a36f386b";
    public static VoiceManager instance;

    IRtcEngine rtcEngine;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        rtcEngine = IRtcEngine.GetEngine(appID);

        rtcEngine.OnJoinChannelSuccess += OnJoinChannelSuccess;
        rtcEngine.OnLeaveChannel += OnLeaveChannel;
        rtcEngine.OnError += OnError;
    }

    private void OnError(int error, string msg)
    {
        Debug.LogError("Error With Agora: " + msg);
    }

    void OnLeaveChannel(RtcStats stats)
    {
        Debug.Log("Left Channel With Duration: " + stats.duration);
    }

    void OnJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        Debug.Log("Joined Channel: " + channelName);
    }

    public override void OnJoinedRoom()
    {
        rtcEngine.JoinChannel(PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnLeftRoom()
    {
        rtcEngine.LeaveChannel();
    }

    private void OnDestroy()
    {
        IRtcEngine.Destroy();
    }
}
