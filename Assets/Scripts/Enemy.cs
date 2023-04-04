using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectBase
{
    public float MoveSpeed => m_moveSpeed;
    [SerializeField] private float m_moveSpeed = 2f;
    private float k_moveSpeedMin = 1f;
    private float k_moveSpeedMax = 3f;

    private void Awake()
    {
        m_moveSpeed = Random.Range(k_moveSpeedMin, k_moveSpeedMax);
    }

    private void FixedUpdate()
    {
        if (!(transform.position.x - Size / 2 > -Screen.width))
        {
            if (!ShouldDestroy)
            {
                ShouldDestroy = true;
                Destroy();
            }
        }
        else
        {
            Move(Vector2.left, m_moveSpeed);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            KillEnemy();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
        }
    }

    private void KillEnemy()
    {
        Destroy();
        GameManager.Instance.SetCurrentScore(GameManager.Instance.CurrentScoreVal + 1);
    }
}
