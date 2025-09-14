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

    private float _nextFireTime = 0f;

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
            var projectile = Instantiate(_projectile, _weaponM.position, _weaponM.rotation);

            if (projectile.Rigidbody != null)
            {
                projectile.Rigidbody.AddForce(_weaponM.up * _force, _forceMode);
            }

            Destroy(projectile.gameObject, _bulletLifetime);
        }
    }
}
