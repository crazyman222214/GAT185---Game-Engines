using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthPickup = 2;
    [SerializeField] GameObject pickupFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.TryGetComponent(out Destructable component))
            {
                component.health += healthPickup;
                Destroy(gameObject);
                if (pickupFX != null)
                {
                    Instantiate(pickupFX, transform.position, Quaternion.identity);
                }
            }
        }

        print(other.gameObject);

    }
}
