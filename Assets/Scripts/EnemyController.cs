using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public PlayerController player;

    private Rigidbody enemyRB;

    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
    }

    void FixedUpdate()
    {
        enemyRB.velocity = (transform.forward * moveSpeed);
    }

    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
}
