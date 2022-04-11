using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private MeteorExplosion fxMeteorExplosion;
    [SerializeField] private bool isFlying;
    public bool IsFlying => isFlying;

    [SerializeField] private bool isGrounded;
    public bool IsGrounded => isGrounded;

    private void Awake()
    {
        isFlying = true;
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            isFlying = false;
        }

        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public void DestroyMeteor()
    {
        Destroy(gameObject);
    }
    public void MeteorExplosion()
    {
        MeteorExplosion newExplosion = Instantiate(fxMeteorExplosion);
        newExplosion.transform.position = transform.position;
        Destroy(gameObject);
    }
}
