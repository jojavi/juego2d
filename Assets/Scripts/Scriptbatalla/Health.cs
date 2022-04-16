using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 3f;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] float destroyDelay = 1f;
    [SerializeField] UnityEvent<float> takeDamage;
    [SerializeField] UnityEvent onDie;

    private float currentHealthPoints;
    private Animator animator;
    private bool isDead = false;

    public event Action onHealthUpdated;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealthPoints = maxHealth;
    }

    public void start(){
        onHealthUpdated?.Invoke();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public float GetPercentage()
    {
        return 100 * GetFraction();
    }

    public float GetFraction()
    {
        return currentHealthPoints / maxHealth;
    }

    public float GetHealthPoints()
    {
        return currentHealthPoints;
    }

    public void SetHealthPoints(float healthPoints)
    {
        currentHealthPoints = healthPoints;
        onHealthUpdated?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        animator.ResetTrigger("takeDamage");
        currentHealthPoints = Mathf.Max(currentHealthPoints - damage, 0);
        takeDamage?.Invoke(damage);
        onHealthUpdated?.Invoke();
        if (currentHealthPoints == 0)
        {
            onDie?.Invoke();
            Die();
        }
        else
        {
            animator.SetTrigger("takeDamage");
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("die");
        if (destroyOnDeath)
        {
            Destroy(gameObject, destroyDelay);
        }
    }
}
