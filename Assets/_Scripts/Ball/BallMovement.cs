using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class BallMovement : MonoBehaviour 
{
    [SerializeField]private float speedMultiplier = 1.0f;

    private Vector2 velocity;
    private Rigidbody2D rigid;
    private CircleCollider2D collider;

    private void Start()
    {
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.rigid.gravityScale = 0;

        this.collider = this.GetComponent<CircleCollider2D>();
        this.collider.isTrigger = true;
        this.reset();
    }

    private void FixedUpdate()
    {
        Vector2 test = this.velocity.normalized * this.speedMultiplier * Time.deltaTime;
        rigid.MovePosition(this.rigid.position + test);
    }

    public void reset()
    {
        this.gameObject.transform.position = Vector3.zero;
        var x = (Random.Range(0, 100) < 50) ? 1 : -1;
        var y = Random.Range(0.1f, 0.5f);
        this.velocity = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            velocity.x *= -1;
            return;
        }

        velocity.y *= -1;
    }
}
