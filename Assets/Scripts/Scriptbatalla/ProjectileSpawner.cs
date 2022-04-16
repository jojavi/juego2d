using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
  
   [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;

    private Team team;
    private void Awake()
    {
        team = GetComponent<Team>();
    }

    public void Fire()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.SetDirection(new Vector2(transform.localScale.x, 0));
        projectile.SetTeamEnum(team.teamEnum);
    }
}
