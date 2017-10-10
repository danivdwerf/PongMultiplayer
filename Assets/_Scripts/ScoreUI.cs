using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour 
{
    [SerializeField]private Text player1Text;
    [SerializeField]private Text player2Text;
    private Score score;

    private void Start()
    {
        this.score = this.GetComponent<Score>();
        score.OnPlayerPoint += this.setScore;
        player1Text.text = "0";
        player2Text.text = "0";
    }

    private void setScore(int p1, int p2)
    {
        player1Text.text = p1.ToString();
        player2Text.text = p2.ToString();
    }
}
