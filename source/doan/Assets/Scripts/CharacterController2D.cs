using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class CharacterController2D : MonoBehaviour
{


    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    [Header("stat")]
    public float hp = 100f;
    public float currenthp = 100f;
    public int money;
    public int score;
    public CareTaker careTaker;
    public Stat statPlayer;

    private static CharacterController2D instance;
    public static CharacterController2D getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();


    }

    private void Start()
    {
		// * lay du lieu tu data
		this.currenthp = statPlayer.hp;
		this.money = statPlayer.money;
		this.score = statPlayer.score;
        EventDispatcher.GetInstance().ui_EventPlayerUpdateAll.Invoke();


		// * Luu tam
        careTaker = new CareTaker();
        careTaker.LevelMarker = this.CreateMarker(this.currenthp,this.money,this.score,this.transform.position);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.TakeDamage(10);
        }
    }
    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }


    }


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }


    public void TakeDamage(float dame)
    {
        this.currenthp -= dame;
        if (this.currenthp < 0)
        {
            this.currenthp = 0;
        }
        EventDispatcher.GetInstance().ui_EventPlayerTakeDame.Invoke();

        if (this.currenthp <= 0)
        {
            Debug.Log("Player Die");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

			this.RestoreLevel(this.careTaker.LevelMarker);
        }

    }

    // * Memento
    public Memento CreateMarker(float hp, int money, int score,Vector3 pos)
    {
        return new Memento(hp, money, score,pos);
    }

    public void RestoreLevel(Memento playerMemento)
    {
        this.currenthp = playerMemento.hp;
        this.money = playerMemento.money;
        this.score = playerMemento.score;
        this.transform.position = playerMemento.posTemp;

        EventDispatcher.GetInstance().ui_EventPlayerUpdateAll.Invoke();

    }




}

//'Memento' class
public class Memento
{
    public float hp;
    public int money;
    public int score;
	public Vector3 posTemp;

    public Memento(float hp, int money, int score,Vector3 pos)
    {
        this.hp = hp;
        this.money = money;
        this.score = score;
		this.posTemp = pos;
    }
}
//'CareTaker' class
public class CareTaker
{
    // save check point before go to next level
    public Memento LevelMarker;
}