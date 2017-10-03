using UnityEngine;
using UnityEngine.UI;

public class NetworkFeedback : MonoBehaviour 
{
    [SerializeField]private Text feedback;

    private void Start()
    {
        feedback.text = "";
    }

    public void setFeedback(string text)
    {
        feedback.text = text;
    }
}
