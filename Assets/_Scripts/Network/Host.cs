using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;

using System.Collections.Generic;


public class Host : MonoBehaviour 
{
    private NetworkMatch matchMaker;

    private void Awake()
    {
        matchMaker = this.gameObject.AddComponent<NetworkMatch>();
    }

    public void joinMatch(NetworkID id)
    {
        matchMaker.JoinMatch(id, "", "", "", 0, 0, onMatchJoined);
    }

    private void onMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (!success)
            return;
        
        print("joined: " + matchInfo.networkId + " : " + matchInfo.address);
    }
}
