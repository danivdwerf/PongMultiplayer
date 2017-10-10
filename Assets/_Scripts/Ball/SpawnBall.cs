using UnityEngine;

public class SpawnBall : Photon.PunBehaviour 
{
    [SerializeField]private string objectName;
    [SerializeField]private int minPlayers;

    private void OnJoinedRoom()
    {
        if (PhotonNetwork.playerList.Length < minPlayers)
            return;

        PhotonNetwork.Instantiate(objectName, Vector3.zero, Quaternion.identity, 0);
    }
}
