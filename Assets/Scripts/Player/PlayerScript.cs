using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    public static int CurrentHealth;
    public int MaxHealth;

    public static bool isDead;
    public static bool isViolet;
    public static bool isGreen;

    private Rigidbody2D myBody;

    [SerializeField] private HealthScript healthBar;

    [SerializeField] private Sprite playerGreen;
    [SerializeField] private Sprite playerViolet;

    public float MoveSpeed = 1f;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate()
    {
        Move();
    }

	void Start()
	{
        isDead = false;
        isViolet = false;
        isGreen = false;

        if(gameObject.GetComponent<SpriteRenderer>().sprite == playerGreen)
		{
            isGreen = true;
            MaxHealth = 4;
		}

        else if(gameObject.GetComponent<SpriteRenderer>().sprite == playerViolet)
		{
            isViolet = true;
		}

        healthBar.SetMaxHealth(MaxHealth);
        CurrentHealth = MaxHealth;
	}

	void Update()
	{
        healthBar.SetHealth(CurrentHealth);
    }
    void Move()
	{
		if(Input.GetAxisRaw("Horizontal") > 0f)
		{
            myBody.velocity = new Vector2(MoveSpeed, myBody.velocity.y);
		}

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-MoveSpeed, myBody.velocity.y);
        }
    }

    public void PlatformMove(float x)
	{
        myBody.velocity = new Vector2(x, myBody.velocity.y);
	}
}
