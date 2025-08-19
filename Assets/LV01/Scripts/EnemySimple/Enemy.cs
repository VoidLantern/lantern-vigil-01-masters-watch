using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Roaming,
        Attack
    }
    public Rigidbody2D enemyRigid;
    private EnemyPathFinding enemyPathFinding;
    public int maxHealth = 2;
    public int currentHealth;
    public float enemyMoveSpeed;



    public State state;

    void Awake()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        enemyPathFinding = GetComponent<EnemyPathFinding>();
        state = State.Roaming;
    }
    void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(5f);
        }
    }

    Vector2 GetRoamingPosition()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), enemyRigid.linearVelocity.y).normalized;
    }

    void Update()
    {

    }



}
