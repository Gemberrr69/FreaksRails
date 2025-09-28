using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] public Rigidbody Rigidbody;

    private ObjectPool<Projectile> _pool;

    public void SetPool(ObjectPool<Projectile> pool)
    {
        _pool = pool;
    }

    void Update()
    {

        if (IsOffScreen())
        {
            _pool.ReturnObject(this);
        }
    }

    bool IsOffScreen()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
        {
            return true;
        }

        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            _pool.ReturnObject(this);
        }
    }
}
