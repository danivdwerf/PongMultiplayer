using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Lobby/Create Match UI")]
public class CreateMatchUI : MonoBehaviour 
{
    [SerializeField]private InputField roomName;
    [SerializeField]private Button submitButton;

    private NetworkManager manager;

    private void Start()
    {
        this.manager = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManager>();
        submitButton.onClick.AddListener(delegate(){manager.createRoom(roomName.text);});
    }
}
