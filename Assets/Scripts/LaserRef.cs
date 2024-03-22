using UnityEngine;

public class ShootPointController : MonoBehaviour
{
    public Transform player; // Referência para o jogador (bola)

    void Update()
    {
        // Atualiza a posição do shootPointReference para seguir o jogador
        transform.position = player.position;
        // Mantém a rotação original do shootPointReference
        transform.rotation = Quaternion.identity;
    }
}
