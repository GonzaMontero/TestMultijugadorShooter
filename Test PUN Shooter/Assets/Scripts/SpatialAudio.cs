using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using agora_gaming_rtc;

public class SpatialAudio : MonoBehaviour
{
    [SerializeField] float radius;

    PhotonView photonView;

    static Dictionary<Player, SpatialAudio> spatialAudioFromPlayers = new Dictionary<Player, SpatialAudio>();

    IAudioEffectManager agoraAudioEffects;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        agoraAudioEffects = VoiceManager.instance.GetRtcEngine().GetAudioEffectManager();
        spatialAudioFromPlayers[photonView.Owner] = this;
    }

    private void OnDestroy()
    {
        spatialAudioFromPlayers.Remove(photonView.Owner);
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        foreach (Player item in PhotonNetwork.CurrentRoom.Players.Values)
        {
            if (item.IsLocal)
                continue;

            if(item.CustomProperties.TryGetValue("agoraID",out object agoraID))
            {
                SpatialAudio other = spatialAudioFromPlayers[item];

                float gain = GetGain(other.transform.position);
                float pan = GetPan(other.transform.position);

                agoraAudioEffects.SetRemoteVoicePosition(uint.Parse((string)agoraID), pan, gain);
            }
        }        
    }

    float GetGain(Vector3 otherPosition)
    {
        float distance = Vector3.Distance(transform.position, otherPosition);
        float gain = Mathf.Max(1 - (distance / radius), 0) * 100f;
        return gain;
    }

    float GetPan(Vector3 otherPosition)
    {
        Vector3 direction = otherPosition - transform.position;
        direction.Normalize();
        float dotProduct = Vector3.Dot(transform.right, direction);
        return dotProduct;
    }
}
