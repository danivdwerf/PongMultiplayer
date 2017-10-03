using System;

using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.Networking;

public class CreateMatch : MonoBehaviour
{
    private MatchUI ui;
    private NetworkFeedback feedback;

    public Action OnCreateMatch;

    private NetworkManager networkManager;

    void Start ()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
            networkManager.StartMatchMaker();

        this.feedback = this.GetComponent<NetworkFeedback>();
    }

    public void create(string name)
    {
        networkManager.matchMaker.CreateMatch(name, 6, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        feedback.setFeedback("Creating match... Please wait.");
    }
}
