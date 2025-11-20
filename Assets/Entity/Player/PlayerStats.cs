using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public PlayerUpgrades playerUpgrades;

    public int currentWave;

    public GameObject waveHandler;
    void Start()
    {
        currentHealth = maxHealth;
        playerUpgrades = new();
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waveHandler.GetComponent<WaveScript>().currentWaveNum;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        currentHealth += playerUpgrades.healthRegen * Time.deltaTime;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
}
