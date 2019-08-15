using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KineticProjectile : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 3.0f;

    public float force = 10;
    public float spread = 5.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Quaternion.AngleAxis(Random.Range(-spread, spread), Vector3.forward) * transform.forward * force;

        Invoke("DestroySelf", lifeTime);
    }

    protected virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
}
