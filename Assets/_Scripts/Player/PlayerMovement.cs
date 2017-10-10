using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : Photon.MonoBehaviour 
{
    [SerializeField]private float speedMultiplier = 2.0f;
    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    private Vector2 movement;

    private void Start()
    {
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.rigid.gravityScale = 0;

        this.collider = this.GetComponent<BoxCollider2D>();

        this.movement = new Vector2(0, 0);
    }

    private void Update()
    {
        if (!photonView.isMine)
            return;
        movement = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (!photonView.isMine)
            return;
        
        Vector2 Velocity = movement.normalized * speedMultiplier * Time.deltaTime;
        this.rigid.MovePosition(this.rigid.position + Velocity);
    }
}
