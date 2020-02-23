using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerWeapon))]
public class PlayerController : MonoBehaviour
{
    [Header("Turrent")]
    public Transform turrentMesh;



    private bool control = true;
    private PlayerHealth playerHealth;
    private PlayerWeapon playerWeapon;
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerWeapon = GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!control)
        {
            return;
        }
    }
}
