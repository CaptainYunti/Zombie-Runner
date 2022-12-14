using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;
    DisplayDamage damageCanvas;
    [SerializeField] float maxDamage = 100f;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        damageCanvas = FindObjectOfType<DisplayDamage>();
    }

    public void AttackHitEvent()
    {
        //float damage = Mathf.Floor(maxDamage * Random.value);
        float damage = Mathf.Floor(maxDamage / 2);
        if (target == null) return;
        Debug.Log("Suck it!");
        target.TakeDamage(damage);
        damageCanvas.ShowDamageCanvas();
    }

}
