using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextPhase : MonoBehaviour
{
    // Nome da próxima cena/fase
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no gatilho é o jogador
        if (other.CompareTag("Player"))
        {
            // Carrega a próxima cena/fase
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
