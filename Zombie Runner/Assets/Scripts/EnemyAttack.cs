using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] float maxDamage = 100f;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        float damage = Mathf.Floor(maxDamage * Random.value);
        if (target == null) return;
        Debug.Log("Suck it!");
        target.TakeDamage(damage);
    }

}
