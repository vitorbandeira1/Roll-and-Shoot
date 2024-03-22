using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float defaultSpeed = 60f; // Velocidade padr�o do jogador
    public float boostedSpeed = 80f; // Velocidade aumentada do jogador
    public float boostDuration = 1f; // Dura��o do aumento de velocidade
    public float jumpForce = 50f; // For�a do salto do jogador
    public GameObject laserPrefab; // Prefab do laser
    public GameObject shootPointReference; // Objeto de refer�ncia para o ponto de origem do disparo
    public float laserSpeed = 100f; // Velocidade do laser
    public float laserLifetime = 2f; // Tempo de vida do laser

    private Rigidbody rb;
    private bool isGrounded;
    private Camera mainCamera;
    private bool isBoosted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Verifica se o jogador est� no ch�o
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        // Movimento horizontal e vertical relativo � dire��o da c�mera
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized * GetCurrentSpeed();
        rb.AddForce(movement);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Disparar laser quando o bot�o esquerdo do mouse � pressionado
        if (Input.GetMouseButtonDown(0))
        {
            ShootLaser();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador passou sobre o piso espec�fico de aumento de velocidade
        if (other.CompareTag("SpeedBoost"))
        {
            // Aumenta temporariamente a velocidade do jogador
            if (!isBoosted)
            {
                StartCoroutine(BoostSpeed());
            }
        }
    }

    IEnumerator BoostSpeed()
    {
        // Aumenta a velocidade do jogador
        isBoosted = true;
        ChangeSpeed(boostedSpeed);

        // Espera pela dura��o do aumento de velocidade
        yield return new WaitForSeconds(boostDuration);

        // Retorna � velocidade padr�o ap�s a dura��o
        isBoosted = false;
        ChangeSpeed(defaultSpeed);
    }

    void ChangeSpeed(float newSpeed)
    {
        // Define a velocidade do jogador
        rb.velocity = rb.velocity.normalized * newSpeed;
    }

    float GetCurrentSpeed()
    {
        // Retorna a velocidade atual do jogador
        if (isBoosted)
        {
            return boostedSpeed;
        }
        else
        {
            return defaultSpeed;
        }
    }

    void ShootLaser()
    {
        // Calcula a dire��o do disparo em rela��o � dire��o da c�mera
        Vector3 shootDirection = mainCamera.transform.forward;
        shootDirection.y = -0.05f;
        // Instancia o objeto do laser no ponto de origem do disparo
        GameObject laser = Instantiate(laserPrefab, shootPointReference.transform.position, Quaternion.LookRotation(shootDirection));

        // Adiciona for�a ao laser para mov�-lo para frente
        Rigidbody laserRB = laser.GetComponent<Rigidbody>();
        laserRB.AddForce(shootDirection * laserSpeed, ForceMode.Impulse);

        // Destroi o laser ap�s alguns segundos para evitar vazamento de mem�ria
        Destroy(laser, laserLifetime);
    }
}
