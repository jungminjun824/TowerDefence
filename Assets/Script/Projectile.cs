using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Transform target;

    public void SetUp(Transform target)
    {
        movement2D = GetComponent<Movement2D>();
        this.target = target;
    }
    private void Update()
    {
        if(target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        if (collision.transform != target) return;

        collision.GetComponent<Enemy>().Ondie();
        Destroy(gameObject);
    }
}
