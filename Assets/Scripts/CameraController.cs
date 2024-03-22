using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public float minHeight = 1.0f; // Altura m�nima da c�mera em rela��o ao jogador
    public float maxHeight = 10.0f; // Altura m�xima da c�mera em rela��o ao jogador
    public float minDistance = 1.0f; // Dist�ncia m�nima da c�mera para o jogador
    public float maxDistance = 20.0f; // Dist�ncia m�xima da c�mera para o jogador
    public float distanceScrollSpeed = 2.0f; // Velocidade de ajuste da dist�ncia com o scroll do mouse
    public float heightDamping = 2.0f; // Velocidade de ajuste suave da altura da c�mera
    public float rotationDamping = 3.0f; // Velocidade de rota��o suave da c�mera
    public float mouseSensitivity = 2.0f; // Sensibilidade do mouse para mover a c�mera

    private float rotationX = 0.0f;
    private float currentDistance;

    void Start()
    {
        currentDistance = Vector3.Distance(transform.position, player.position);
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Rota��o da c�mera baseada na posi��o do mouse
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationX += mouseX * rotationDamping;

            // Calcula a rota��o da c�mera
            Quaternion currentRotation = Quaternion.Euler(0, rotationX, 0);

            // Ajuste da dist�ncia da c�mera com scroll do mouse
            currentDistance -= Input.GetAxis("Mouse ScrollWheel") * distanceScrollSpeed;
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

            // Calcula a posi��o desejada da c�mera
            float wantedHeight = player.position.y + (maxHeight + minHeight) / 2;
            float finalHeight = Mathf.Lerp(transform.position.y, wantedHeight, heightDamping * Time.deltaTime);

            Vector3 newPosition = player.position;
            newPosition -= currentRotation * Vector3.forward * currentDistance;
            newPosition.y = finalHeight;

            transform.position = newPosition;

            transform.LookAt(player.position);
        }
    }
}
