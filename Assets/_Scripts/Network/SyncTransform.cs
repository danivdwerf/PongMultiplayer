using UnityEngine;

[AddComponentMenu("Networking/Sync Transform")]
public class SyncTransform : Photon.MonoBehaviour 
{
    private Vector3 position;
    private Quaternion rotation;

    private void Awake()
    {
        this.position = Vector3.zero;
        this.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (photonView.isMine)
            return;

        transform.position = Vector3.Lerp(transform.position, this.position, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, this.rotation, 0.1f);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            return;
        }

        this.position = (Vector3)stream.ReceiveNext();
        this.rotation = (Quaternion)stream.ReceiveNext();
    }
}
