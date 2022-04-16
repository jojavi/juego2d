using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float velocity = 3f;

    private Collider2D pCollider;
    private Rigidbody2D rb;
    private TeamEnum teamEnum;

    private void Awake()
    {
        pCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTeamEnum(TeamEnum teamEnum)
    {
        this.teamEnum = teamEnum;
    }

    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction.normalized * velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.TryGetComponent<Health>(out Health otherHealth)) { return; }
        if (!other.gameObject.TryGetComponent<Team>(out Team otherTeam)) { return; }
        if (otherTeam.teamEnum == teamEnum) { return; }

        otherHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
}
