using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTimeController : MonoBehaviour
{

    List<Weapon> weaponsLine;

    private void Start()
    {
        weaponsLine = new List<Weapon>();
    }

    public bool CanShoot(Weapon weapon)
    {
            if (weaponsLine.Contains(weapon))
            {
                return false;
            }
            return true;
    }

    public void StartShoot(Weapon weapon, float timeBetweenShots)
    {
        if (weaponsLine.Contains(weapon))
        {
            return;
        }    
        weaponsLine.Add(weapon);
        StartCoroutine(ShootTime(weapon, timeBetweenShots));
    }

    IEnumerator ShootTime(Weapon weapon, float timeBetweenShots)
    {
        yield return new WaitForSeconds(timeBetweenShots);
        weaponsLine.Remove(weapon);
    }
}
