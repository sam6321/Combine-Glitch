using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 move = new Vector2();

    [SerializeField]
    private float speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(world);

        move.Set(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
    }

    void FixedUpdate()
    {
        rb.AddForce(move.normalized * Time.fixedDeltaTime * speed);
    }
}
