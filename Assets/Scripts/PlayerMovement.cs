using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movimentação")]
    public float speed = 6f;
    public float velocidadeCorrendo = 12f;
    private bool podeCorrer = false;

    private float originalSpeed;
    private float boostTimer = 0f;

    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public bool doubleJump = false;
    public bool secondJump = false;

    [Header("Mouse Look")]
    public Transform cameraTransform;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public int maxHealth = 10;
    public int currenthealth;

    void Start()
    {
        currenthealth = maxHealth;
        originalSpeed = speed;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
            {
                speed = originalSpeed;
            }
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            if (doubleJump) secondJump = true;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        float velocidadeAtual = speed;

        if (podeCorrer && Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeAtual = velocidadeCorrendo;
        }

        controller.Move(move * velocidadeAtual * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (doubleJump && !isGrounded)
        {
            if (secondJump && Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                secondJump = false;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (currenthealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AtivarBoostVelocidade(float novaVelocidade, float duracao)
    {
        speed = novaVelocidade;
        boostTimer = duracao;
    }

    public void SetVelocidadePermanente(float novaVelocidade)
    {
        speed = novaVelocidade;
        originalSpeed = novaVelocidade;
    }

    public void HabilitarCorrida()
    {
        podeCorrer = true;
    }
}
