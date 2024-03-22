using UnityEngine;

public class ShootPointController : MonoBehaviour
{
    public Transform player; // Refer�ncia para o jogador (bola)

    void Update()
    {
        // Atualiza a posi��o do shootPointReference para seguir o jogador
        transform.position = player.position;
        // Mant�m a rota��o original do shootPointReference
        transform.rotation = Quaternion.identity;
    }
}
