using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private float _ReloadTimes;
    [SerializeField] protected Text _ammoCount;

    private int _currentAmmo;

    public float Damage;
    public bool Reloading=false;
    public Camera fpsCam;
    public event UnityAction<int, int> AmmopChanged;

    void Start()
    {
        

        if (_currentAmmo == -1)
            _currentAmmo = _maxAmmo;

    }
    private void OnEnable()
    {
        Reloading = false;
    }
    void Update()
    {
        _ammoCount.text = "Ammo" +_currentAmmo + "/"+ _maxAmmo;

        if (Reloading)
            return;

        if (Input.GetButtonDown("Fire1"))
            Shooting();
        if (_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator Reload()
    {
        Reloading = true;
        Debug.Log("reloading...");

        yield return new WaitForSeconds(_ReloadTimes);

        _currentAmmo = _maxAmmo;
        Reloading=false;
    }

    void Shooting()
    {
        _currentAmmo--;
        AmmopChanged?.Invoke(_currentAmmo, _maxAmmo);

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, _range))
        {
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Debug.Log(hit.transform.name);

                enemyHealth.TakeDamege(Damage);
            }

        }

    }
}
