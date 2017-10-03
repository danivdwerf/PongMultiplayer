using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour 
{
    private NetworkFeedback feedback;
    private NetworkManager networkManager;

    void Start ()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
            networkManager.StartMatchMaker();

        this.feedback = this.GetComponent<NetworkFeedback>();
    }

    public void joinGame(NetworkID matchID)
    {
        NetworkManager.singleton.matchMaker.JoinMatch(matchID, "", "", "", 0, 0, networkManager.OnMatchJoined);
        feedback.setFeedback("Joining game... Please wait");
    }
}
