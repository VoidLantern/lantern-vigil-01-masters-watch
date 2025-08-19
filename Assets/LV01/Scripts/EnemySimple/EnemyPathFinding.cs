using System;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    private Enemy enemy;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    public bool isAttack = false;
    public LayerMask playerLayer;
    void Awake()
    {
        enemy = GetComponent<Enemy>();
        rb = enemy.enemyRigid;
        moveSpeed = enemy.enemyMoveSpeed;
    }

    void FixedUpdate()
    {
        ColDec();
        if (isAttack) enemy.state = Enemy.State.Attack;
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }

    void ColDec()
    {
        isAttack = Physics2D.Raycast(transform.position, Vector2.right * moveDir.x, 3f, playerLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(3f * moveDir.x, 0));
    }
}
