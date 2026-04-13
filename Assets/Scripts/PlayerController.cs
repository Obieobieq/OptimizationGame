using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    private Vector2 input;

    public float speed;
    private float attack;

    public GameObject arrowPrefab;
    public Transform arrowShootLocation;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        transform.position = transform.position + new Vector3(0, input.y * speed * Time.deltaTime, 0);
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -2.5f, 2.5f);
        transform.position = pos;
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void OnAttack(InputValue value)
    {
        attack = value.Get<float>();
        animator.SetFloat("Attack", attack);
        Invoke("ResetAttackValue", 0.2f);
        Instantiate(arrowPrefab, arrowShootLocation.position, Quaternion.Euler(0, 0, -90));

        if (attack == 1)
        {
            Debug.Log(attack);
        }
    }

    void OnRestart(InputValue value)
    {
        if (gameManager.playerDied)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void ResetAttackValue()
    { 
        attack = 0;
        animator.SetFloat("Attack", attack);
    }
}
