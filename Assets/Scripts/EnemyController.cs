using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public int totalHealth;

    private PlayerController player;
    private Rigidbody enemyRB;

    [SerializeField] private int currentHealth;

    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
        currentHealth = totalHealth;
    }

    void FixedUpdate()
    {
        enemyRB.velocity = (transform.forward * moveSpeed);
    }

    void Update()
    {
        transform.LookAt (new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage (int damageAmount)
    {
        currentHealth -= damageAmount;
    }

    void AttackPlayer()
    {
        player.DamagePlayer(1);
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttackPlayer();
        }
    }
}
