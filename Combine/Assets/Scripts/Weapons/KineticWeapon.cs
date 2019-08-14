using UnityEngine;

public class KineticWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireDelay = 0.1f;

    private float lastFire = 0;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > lastFire + fireDelay)
        {
            Instantiate(
                projectile,
                transform.position + (Vector3)Random.insideUnitCircle * 0.2f,
                transform.rotation * Quaternion.AngleAxis(Random.Range(-10, 10), Vector3.forward)
            );
            lastFire = Time.time;
        }
    }
}
