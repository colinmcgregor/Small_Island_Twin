using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerHealth;
    public GameObject bulletPrefab;
    public Transform gunBarrel;
    
    private Vector3 movement;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    private Animator anim;
    
    private int currentHealth;
    private float movementSpeed = 5.0f;
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
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
            anim.SetTrigger("Dead");
            this.gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    void PlayerMove()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = movement * movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            transform.position += moveVelocity;
        }
        // else
        // {
        //     anim.SetBool("isWalking", false);
        // }
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

    public void DamagePlayer (int damageAmount)
    {
        currentHealth -= damageAmount;
        //anim.SetTrigger("Get_Hit");
    }

    void ShootGun()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Shooting");
            Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        }
    }
}
