using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //SINGLETON pattern
    public static PlayerInput Instance;
   
    private void Awake()
    {
        if (Instance == null)// ONly one instance of playerinput
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //SINGLETON pattern

    [SerializeField] private MoveAbility moveAbility;
    [SerializeField] private LookAbility lookAbility;
    [SerializeField] private ShootingAbility shootAbility;
    [SerializeField] private JumpAbility jumpAbility;
    [SerializeField] private Interactability interactability;
    [SerializeField] private CommanderAbility commandAbility;
    
    
    //Directional Inputs
    private Vector2 lookDirection;

    [SerializeField] private float mouseSensitivity;//strictly for the player

    //Gravity and Jumping Settings
    [SerializeField] private float gravityForce;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthSystem>().OnDead += () =>
        {
            this.enabled = false;
        };

        //Controll of Mouse Cursor
        Cursor.visible = false; //Visibility of the cursor
        Cursor.lockState = CursorLockMode.Locked; //Locked to the center of the screen   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAbility.Jump();
        }

        if (moveAbility)
        {
            Vector3 moveDir = new Vector3();
            moveDir.x = Input.GetAxis("Horizontal");
            moveDir.z = Input.GetAxis("Vertical");
            moveAbility.Move(moveDir);

        }

        if (lookAbility)
        {
            lookDirection.x += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            lookDirection.y += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;


            float angleOnY = lookDirection.y;
            lookDirection.y = Mathf.Clamp(angleOnY, -80, 80);

            lookAbility.Look(lookDirection);

        }

        if (shootAbility != null && Input.GetMouseButtonDown(0))
        {
            shootAbility.Shoot();
        }        

        if (interactability && Input.GetKeyDown(KeyCode.F))
        {
            interactability.Interact();
        }

        if (commandAbility && Input.GetMouseButtonDown(1))
        {
            commandAbility.Command();
        }
    }

    //testing the sphere location
    private void OnDrawGizmos()
    {
        //drawing a sphere right at the feet of the player
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

  
}
