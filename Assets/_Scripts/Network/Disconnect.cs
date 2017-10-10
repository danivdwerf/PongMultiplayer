using UnityEngine;

[AddComponentMenu("Networking/Disconnect")]
public class Disconnect : MonoBehaviour 
{
    public void disconnectFromRoom()
    {
        PhotonNetwork.Disconnect();
    }
}
