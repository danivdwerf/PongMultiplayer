using UnityEngine;
using UnityEngine.UI;

public class MatchUI : MonoBehaviour 
{
    [SerializeField]private GameObject lobbyPanel;
    [SerializeField]private InputField roomName;
    [SerializeField]private Button createButton;

    private CreateMatch matchCreater;

    private void Start()
    {
        this.matchCreater = this.GetComponent<CreateMatch>();
        matchCreater.OnCreateMatch += hideMatchmaker;

        createButton.onClick.AddListener(delegate(){matchCreater.create(roomName.text);});
    }

    public void hideMatchmaker()
    {
        lobbyPanel.SetActive(false);
    }

}
