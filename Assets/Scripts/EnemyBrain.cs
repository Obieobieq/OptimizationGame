using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("KillEnemy", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void KillEnemy()
    {
        animator.SetBool("isDead", true);
        Debug.Log("Dead");
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
