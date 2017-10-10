using UnityEngine;
using UnityEngine.UI;

public class DisconnectUI : MonoBehaviour 
{
    private Disconnect disconnect;
    [SerializeField]private Button disconnectButton;

    private void Start()
    {
        this.disconnect = FindObjectOfType<Disconnect>();
        disconnectButton.onClick.AddListener(delegate(){disconnect.disconnectFromRoom();});
    }
}
