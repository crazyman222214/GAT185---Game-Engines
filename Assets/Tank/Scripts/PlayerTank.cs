using TMPro;
using UnityEngine;

public class PlayerTank : MonoBehaviour, IDamageable
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 100;
    [SerializeField] GameObject rocket;
    [SerializeField] Transform barrel;
    [Range(5, 20)] public int ammo = 10;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] Destructable destructable;


    float torque;
    float force;

    Rigidbody rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

       

        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            Instantiate(rocket, barrel.position, barrel.rotation);
            ammo--;
        }

        ammoText.text = "Ammo: " + ammo.ToString();
        healthText.text = "Health: " + destructable.health.ToString();
        print(destructable.health);
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }

    public void ApplyDamage(float damage)
    {
        
    }
}
