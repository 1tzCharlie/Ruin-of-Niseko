using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public GameObject aim;

    Vector2 movement;
    Vector2 mousePos;

    Camera cam;

    public SpellBase equippedSpell;
    public SpellBase secondarySpell;

    private void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
            health = maxHealth;
        else if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Ded");
        }
    }

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        aim.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (movement.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (movement.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
