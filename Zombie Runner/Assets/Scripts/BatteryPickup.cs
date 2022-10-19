using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    [SerializeField] float lightAngleToRestore = 80f;
    [SerializeField] float lightIntensityToRestore = 1f;

    GameObject player;
    FlashLightSystem playerFlash;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerFlash = player.GetComponentInChildren<FlashLightSystem>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerFlash.RestoreLightAngle(lightAngleToRestore);
            playerFlash.RestoreLightIntensity(lightIntensityToRestore);
            Destroy(gameObject);
        }
    }
}
