using UnityEngine;

public class Alvo : MonoBehaviour
{
    private RespawnFloor respawnFloor;

    void Start()
    {
        respawnFloor = FindObjectOfType<RespawnFloor>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colidiu enemy");
            respawnFloor.RespawnPlayer(true); // Indica que o jogador foi atingido pelo inimigo
           
        }
        else if (other.CompareTag("Laser"))
        {
            Debug.Log("Lase Enemmy");
            Destroy(gameObject);
        }
    }
}
