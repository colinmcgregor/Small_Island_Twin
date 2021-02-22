using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 20.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        Destroy(this.gameObject, 3.0f);
    }
}
