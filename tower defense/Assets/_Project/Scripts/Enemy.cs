
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float health = 100f;
    
    public NavMeshAgent NavAgent;

    void Awake()
    {
        NavAgent = GetComponent<NavMeshAgent>();
    }
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float damage = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
            DoDamage();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
    void DoDamage()
    {
        PlayerHealth.Instance.TakeDamage(damage);
    }
    
}
