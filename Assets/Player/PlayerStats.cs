using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public PlayerUpgrades playerUpgrades;

    public int currentWave;

    public GameObject waveHandler;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waveHandler.GetComponent<WaveScript>().currentWaveNum;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
