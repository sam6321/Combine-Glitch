using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KineticProjectile : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 3.0f;

    [SerializeField]
    private float spawnForce = 10;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * spawnForce;

        Invoke("DestroySelf", lifeTime);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
