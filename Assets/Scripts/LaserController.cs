using UnityEngine;

public class Laser : MonoBehaviour
{
    public float timeToAdd = 3f;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o laser colidiu com um alvo
        if (other.CompareTag("Alvo"))
        {
            Timer timer = FindObjectOfType<Timer>(); // Encontra o Timer na cena
            if (timer != null)
            {
                timer.AddTime(timeToAdd); // Adiciona tempo ao timer
            }
            // Adicione sua lógica aqui, por exemplo:
            // Pontuar, exibir efeitos visuais ou destruir o alvo
            Debug.Log("Laser atingiu um alvo!");
            Destroy(other.gameObject); // Destroi o alvo
            Destroy(gameObject); // Destroi o laser após colidir com um alvo
        }
    }
}
