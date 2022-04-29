using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESSProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Transform explosion;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            ProjectileExplosion();
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    public void ProjectileExplosion()
    {
        Transform newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
        newExplosion.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(this.gameObject);
    }

}
