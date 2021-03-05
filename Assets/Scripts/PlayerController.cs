using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int playerHealth;
    public bool isAlive;
    public GameObject bulletPrefab;
    public Transform gunBarrel;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI killsText;
    
    private Vector3 movement;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    private Animator anim;
    
    private int currentHealth;
    private int totalKills;
    private float movementSpeed = 5.0f;

    
    void Start()
    {
        isAlive = true;
        totalKills = 0;
        anim = this.GetComponent<Animator>();
        mainCamera = Camera.main;
        currentHealth = playerHealth;

        healthText.text = $"Health: {currentHealth.ToString()}";
        killsText.text = $"Kills: {totalKills.ToString()}";
    }

    void Update()
    {
        LookAtMouse();
        PlayerMove();
        ShootGun();

        if (currentHealth <= 0)
        {
            anim.SetTrigger("Dead");
            isAlive = false;
            Time.timeScale = 0;
        }
    }

    void PlayerMove()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = movement * movementSpeed * Time.deltaTime;

        if (movement.magnitude >= 0.1f)
        {
            transform.position += moveVelocity;
            Walk();
        }
        else
        {
            Idle();
        }
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
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
        healthText.text = $"Health: {currentHealth.ToString()}";
        //anim.SetTrigger("Get_Hit");
    }

    void ShootGun()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
            Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        }
    }

    public void IncrementKills()
    {
        totalKills++;
        killsText.text = $"Kills: {totalKills.ToString()}";
    }
}
