using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public float attackRange = 5.0f; // 타워의 공격 범위
    public float attackCooldown = 1.0f; // 공격 대기 시간
    public GameObject bulletPrefab; // 탄환 프리팹
    public Transform firePoint; // 탄환이 발사될 위치

    private float lastAttackTime = 0f; // 마지막 공격 시간
    private List<Transform> enemiesInRange = new List<Transform>(); // 범위 내의 몬스터 목록

    void Update()
    {
        // 공격 대기 시간이 지났는지 확인
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time; // 마지막 공격 시간 업데이트
        }
    }

    void Attack()
    {
        // 범위 내에 적이 있는지 확인하고, 가장 가까운 적을 공격
        if (enemiesInRange.Count > 0)
        {
            Transform targetEnemy = enemiesInRange[0]; // 간단히 첫 번째 적을 타겟으로 설정
            float closestDistance = Vector2.Distance(transform.position, targetEnemy.position);

            foreach (Transform enemy in enemiesInRange)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.position);
                if (distanceToEnemy < closestDistance)
                {
                    targetEnemy = enemy;
                    closestDistance = distanceToEnemy;
                }
            }

            // 탄환 생성 및 발사
            Shoot(targetEnemy);
        }
    }

    void Shoot(Transform targetEnemy)
    {
        // 탄환 생성 및 발사 위치 설정
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        TowerBullet bulletScript = bullet.GetComponent<TowerBullet>();
        if (bulletScript != null)
        {
            bulletScript.SetTarget(targetEnemy); // 탄환의 타겟 설정
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.transform); // 범위 내에 들어온 적 추가
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.transform); // 범위에서 벗어난 적 제거
        }
    }

    // 공격 범위 시각화를 위해 에디터에 표시
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
