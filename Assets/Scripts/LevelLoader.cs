using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextPhase : MonoBehaviour
{
    // Nome da pr�xima cena/fase
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no gatilho � o jogador
        if (other.CompareTag("Player"))
        {
            // Carrega a pr�xima cena/fase
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
