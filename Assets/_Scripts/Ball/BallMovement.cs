using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class BallMovement : MonoBehaviour 
{
    [SerializeField]private float speedMultiplier = 1;

    private Vector2 velocity;
    private Rigidbody2D rigid;
    private CircleCollider2D collider;

    private void Start()
    {
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.rigid.gravityScale = 0;

        this.collider = this.GetComponent<CircleCollider2D>();
        this.collider.isTrigger = true;

        this.velocity = new Vector2(1, 0.5f);
    }

    private void FixedUpdate()
    {
        Vector2 test = this.velocity * this.speedMultiplier * Time.deltaTime;
        rigid.MovePosition(this.rigid.position + test);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.velocity = Vector3.Reflect(-this.velocity, other.transform.forward);
    }
}
