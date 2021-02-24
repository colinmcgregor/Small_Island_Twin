using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunBarrel;
    public int playerHealth;

    private Rigidbody playerRB;
    private Vector3 movement;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    private int currentHealth;

    private float movementSpeed = 5.0f;
    
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        currentHealth = playerHealth;
    }

    void Update()
    {
        LookAtMouse();
        PlayerMove();
        ShootGun();

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);            
        }
    }

    void FixedUpdate()
    {
        playerRB.velocity = moveVelocity;
    }

    void PlayerMove()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = movement * movementSpeed;
    }

    void LookAtMouse()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLookAt = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z));
        }
    }

    void ShootGun()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        }
    }

    public void DamagePlayer (int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"Current Health {currentHealth}");
    }
}
