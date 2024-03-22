using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    private bool enemyHit = false; // Variável para indicar se o jogador foi atingido pelo inimigo

    public void RespawnPlayer(bool enemyHit)
    {
        this.enemyHit = enemyHit;
        player.transform.position = respawnPoint.transform.position;
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        playerRigidbody.velocity = Vector3.zero; // Define a velocidade do jogador como zero
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enemyHit && other.CompareTag("Player"))
        {   Debug.Log("Respawnn");
            RespawnPlayer(false); // O jogador caiu das plataformas
        }
    }
}
