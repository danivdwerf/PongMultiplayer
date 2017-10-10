using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Lobby/Feedback UI")]
public class LobbyFeedback : MonoBehaviour 
{
    [SerializeField]private Text feedback;
    private NetworkManager manager;

    private void Start()
    {
        this.manager = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManager>();
        manager.OnFeedback += this.setFeedback;
        feedback.text = "";
    }

    public void setFeedback(string text)
    {
        feedback.text = text;
    }
}
