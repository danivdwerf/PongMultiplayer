using UnityEngine;
using System;

public class BallDetection : MonoBehaviour 
{
    [SerializeField]private int playerNumber;
    public Action<int> OnBallEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Ball")
            return;

        if (OnBallEnter == null)
            return;
        
        OnBallEnter(playerNumber);
        other.transform.position = Vector3.zero;
    }
}
