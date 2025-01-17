using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 100;
    public GameObject rocket;

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
        torque = Input.GetAxis("Horizontal");
        force = Input.GetAxis("Vertical");

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(rocket, transform.position + Vector3.up, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }
}
