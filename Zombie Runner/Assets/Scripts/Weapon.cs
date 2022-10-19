using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] Transform gameManager;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;
    WeaponTimeController timeController;

    private void Awake()
    {
        timeController = gameManager.GetComponent<WeaponTimeController>();
    }


    void Update()
    {
        DisplayAmmo();
        canShoot = timeController.CanShoot(this);
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            timeController.StartShoot(this, timeBetweenShots);
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }


    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
       GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
