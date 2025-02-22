using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    public Transform turretGfx; 
    
    public float detectionRadius = 10f;
    public float rotationSpeed = 5f;
    public float fireRate = 1f;
    public float damage = 10f;
    private float fireCooldown = 0f;

    private Transform target;

    void Update()
    {
        FindTarget();

        if (target == null) return;

        RotateTurret();

        if (IsFacingTarget() && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    void FindTarget()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Enemy"));
        Transform bestTarget = null;
        float shortestPathDistance = Mathf.Infinity;

        foreach (Collider enemyCollider in enemies)
        {
            
            Enemy enemy = enemyCollider.gameObject.GetComponent<Enemy>();
            if (enemy == null) continue;
            
            float pathDistance = enemy.gameObject.GetComponent<NavMeshAgent>().GetPathRemainingDistance();
            if (pathDistance < shortestPathDistance)
            {
                shortestPathDistance = pathDistance;
                bestTarget = enemy.transform;
            }
        }

        target = bestTarget;
    }

   

    void RotateTurret()
    {
        Vector3 direction = target.position - turretGfx.position;
        
       quaternion lookTarget = Quaternion.LookRotation(direction);
        Vector3 rotate = Quaternion.Lerp(turretGfx.rotation, lookTarget, rotationSpeed * Time.deltaTime).eulerAngles;
        
       turretGfx.rotation = Quaternion.Euler(-90f, rotate.y, 90f);
    }

    bool IsFacingTarget()
    {
        Vector3 directionToTarget = (target.position - turretGfx.position).normalized;
        float angleDifference = Vector3.Angle(turretGfx.forward, directionToTarget) -70f;
        print(angleDifference);
        return angleDifference < 95f; 
    }

    void Shoot()
    {
        target.GetComponent<Enemy>().TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
