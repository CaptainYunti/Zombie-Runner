using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float displayTime = 1f;
    [SerializeField] Canvas damageCanvas;


    private void Start()
    {
        damageCanvas.enabled = false;
    }

    public void ShowDamageCanvas()
    {
        StopAllCoroutines();
        StartCoroutine(DamageCanvasCoroutine());
    }

    IEnumerator DamageCanvasCoroutine()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(displayTime);
        damageCanvas.enabled = false;

    }
}
