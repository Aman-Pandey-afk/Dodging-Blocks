using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    float screenWidth, playerWidth;
    public float speed = 3;
    Vector2 velocity;
    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(600, 1000, true);
        playerWidth = transform.localScale.x / 2;
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize + playerWidth;


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        velocity = speed * direction;
        transform.Translate(velocity * Time.deltaTime);

        if (transform.position.x > screenWidth)
        {
            transform.position = new Vector2(-screenWidth, transform.position.y);
        }
        if (transform.position.x < -screenWidth) transform.position = new Vector2(screenWidth, transform.position.y);
    }
    private void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "Collider")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);


        }
    }
}
