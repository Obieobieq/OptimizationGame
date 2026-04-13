using UnityEngine;
using UnityEngine.Windows;

public class EnemyBrain : MonoBehaviour
{
    Animator animator;
    private GameManager gameManagerScript;
    private GameObject gameManagerObject;

    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        animator = gameObject.GetComponent<Animator>();
        Invoke("KillEnemy", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
    }

    // Check for if the enemy reaches the end and removes a "heart", also checks if its been hit by an arrow and dies
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndZone")
        {
            EnemyInEndZone();
        }
        else if (collision.tag == "Arrow")
        { 
            KillEnemy();
            Destroy(collision.gameObject);
        }
    }

    //Logic for if enemy reaches the endzone
    void EnemyInEndZone()
    {
        gameManagerScript.HealthLowered();
        gameManagerScript.RemoveEnemies();
    }

    void KillEnemy() //Sets the enemy to play its death animation and die
    {
        speed = 0;
        animator.SetBool("isDead", true);
        Debug.Log("Dead");
    }

    void DestroyEnemy() //Gets called by the animator
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameManagerScript.UpdateScore(10);
    }
}
