using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public float speed = 10f; // 탄환의 속도
    public int damage = 10; // 탄환의 공격력

    private Transform target;

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // 타겟이 없으면 탄환을 파괴
            return;
        }

        // 타겟 방향으로 탄환을 이동
        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // 타겟에 도달했는지 확인
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        MonsterLogic enemy = target.GetComponent<MonsterLogic>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // 적에게 데미지 입히기
        }
        Destroy(gameObject); // 탄환 파괴
    }
}