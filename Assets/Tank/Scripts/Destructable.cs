using UnityEngine;

public class Destructable : MonoBehaviour, IDamageable
{
    public float health = 20;
    [SerializeField] GameObject destroyFX;
    bool destroyed = false;

    public void ApplyDamage(float damage)
    {
        if (destroyed) return;
        health -= damage;
        if (health <= 0)
        {
            destroyed = true;
            Instantiate(destroyFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
