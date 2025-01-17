using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoCount = 5;
    [SerializeField] GameObject pickupFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.TryGetComponent(out PlayerTank component))
            {
                component.ammo += ammoCount;
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
