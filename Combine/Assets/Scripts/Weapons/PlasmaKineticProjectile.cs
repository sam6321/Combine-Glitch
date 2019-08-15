using UnityEngine;

public class PlasmaKineticProjectile : KineticProjectile
{
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float explosionRadius;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            CreateExplosion();
            Destroy(gameObject);
        }
    }

    protected override void DestroySelf()
    {
        CreateExplosion();
        base.DestroySelf();
    }

    private void CreateExplosion()
    {
        int mask = LayerMask.GetMask("Enemy");
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, explosionRadius, mask))
        {
            // Deal damage
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
