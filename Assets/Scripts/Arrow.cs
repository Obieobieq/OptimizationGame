using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        ArrowMovement();
    }

    void ArrowMovement()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }

}
