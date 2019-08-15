using UnityEngine;

public class KineticWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireDelay = 0.1f;

    [SerializeField]
    private float force = 10;

    [SerializeField]
    private float spread = 5;

    private float lastFire = 0;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > lastFire + fireDelay)
        {
            var spawnedProjectile = Instantiate(
                projectile,
                transform.position + (Vector3)Random.insideUnitCircle * 0.2f,
                transform.rotation
            ).GetComponent<KineticProjectile>();
            spawnedProjectile.force = force;
            spawnedProjectile.spread = spread;

            lastFire = Time.time;
        }
    }
}
