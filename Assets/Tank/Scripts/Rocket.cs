using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float force = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
