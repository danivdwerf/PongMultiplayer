using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]private float speedMultiplier = 2.0f;
    private Rigidbody2D rigid;
    private Vector2 movement;

    private void Start()
    {
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.rigid.gravityScale = 0;

        this.movement = new Vector2(0, 0);
    }

    private void Update()
    {
        movement = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        Vector2 Velocity = movement.normalized * speedMultiplier * Time.deltaTime;
        this.rigid.MovePosition(this.rigid.position + Velocity);
    }
}
