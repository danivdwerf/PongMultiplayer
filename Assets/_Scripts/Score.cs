using UnityEngine;
using System;

public class Score : MonoBehaviour 
{
    private int player1;
    private int player2;

    private BallDetection[] ballDetection;

    public Action<int, int> OnPlayerPoint;

    private void Awake()
    {
        this.player1 = this.player2 = 0;
        ballDetection = FindObjectsOfType<BallDetection>();
        for (var i = 0; i < ballDetection.Length; i++)
        {
            ballDetection[i].OnBallEnter += this.checkScore;
        }
    }

    private void checkScore(int playerNumber)
    {
        if (playerNumber == 1)
            player2++;
        else
            player1++;

        if (OnPlayerPoint == null)
            return;

        OnPlayerPoint(player1, player2);
    }
}
