using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float minHeight = 1.0f; // Altura mínima da câmera em relação ao jogador
    public float maxHeight = 10.0f; // Altura máxima da câmera em relação ao jogador
    public float minDistance = 1.0f; // Distância mínima da câmera para o jogador
    public float maxDistance = 20.0f; // Distância máxima da câmera para o jogador
    public float distanceScrollSpeed = 2.0f; // Velocidade de ajuste da distância com o scroll do mouse
    public float heightDamping = 2.0f; // Velocidade de ajuste suave da altura da câmera
    public float rotationDamping = 3.0f; // Velocidade de rotação suave da câmera
    public float mouseSensitivity = 2.0f; // Sensibilidade do mouse para mover a câmera

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
            // Rotação da câmera baseada na posição do mouse
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationX += mouseX * rotationDamping;

            // Calcula a rotação da câmera
            Quaternion currentRotation = Quaternion.Euler(0, rotationX, 0);

            // Ajuste da distância da câmera com scroll do mouse
            currentDistance -= Input.GetAxis("Mouse ScrollWheel") * distanceScrollSpeed;
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

            // Calcula a posição desejada da câmera
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
