using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int bulletDamage = 1;

    private float bulletSpeed = 20.0f;
    private float timeToDestroyBullet = 3.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        Destroy(this.gameObject, timeToDestroyBullet);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage(bulletDamage);
        }

        Destroy(this.gameObject);
    }
}
