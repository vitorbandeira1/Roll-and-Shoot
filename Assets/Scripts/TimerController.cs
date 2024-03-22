using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Adiciona a biblioteca de gerenciamento de cenas

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; // Corrigido para TextMeshProUGUI
    [SerializeField] float remainingTime;
    public string gameOverSceneName; // Nome da cena de Game Over

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay(); // Atualiza o display do timer
        }
        else
        {
            remainingTime = 0;
            UpdateTimerDisplay(); // Atualiza o display do timer
            GameOver(); // Chama o método GameOver quando o tempo acabar
        }
    }

    // Método para adicionar tempo ao temporizador
    public void AddTime(float amount)
    {
        remainingTime += amount;
        UpdateTimerDisplay(); // Atualiza o display do timer
    }

    // Método para atualizar o display do temporizador
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Método para carregar a cena de Game Over
    private void GameOver()
    {
        SceneManager.LoadSceneAsync(4); // Carrega a cena de Game Over
    }
}
