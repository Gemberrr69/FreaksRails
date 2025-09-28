using Unity.VisualScripting;
using UnityEngine;

public class IneedMoreBullets : MonoBehaviour
{
    [Header("Ссылки")]
    [SerializeField] private Transform _weaponM;
    [SerializeField] private Projectile _projectile;

    [Header("Настройки стрельбы")]
    [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;
    [SerializeField] private float _force = 20f;
    [SerializeField] private float _fireRate = 0.2f;
    [SerializeField] private float _bulletLifetime = 5f;
    private ObjectPool<Projectile> _bullpool;
    private float _nextFireTime = 0f;
    private void Start()
    {
        _bullpool = new ObjectPool<Projectile>(_projectile);

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + _fireRate;
        }
    }

    public void Shoot()
    {
        if (_projectile != null && _weaponM != null)
        {
            //var projectile = instantiate(_projectile, _weaponm.position, _weaponm.rotation);
            var projectile = _bullpool.GetObject();
            projectile.SetPool(_bullpool);
            projectile.transform.position = _weaponM.position;
            projectile.transform.rotation = _weaponM.rotation;
            projectile.gameObject.SetActive(true);

            if (projectile.Rigidbody != null)
            {
                projectile.Rigidbody.angularVelocity = Vector3.zero;
                projectile.Rigidbody.linearVelocity = Vector3.zero;
                projectile.Rigidbody.AddForce(_weaponM.up * _force, _forceMode);
            }

            //Destroy(projectile.gameObject, _bulletLifetime);
        }
    }

}
