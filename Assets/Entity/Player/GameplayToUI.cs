using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerStats))]
public class GameplayToUI : MonoBehaviour
{
    GameObject UI;
    GameObject currHealthUI;
    GameObject currWaveUI;

    void Awake()
    {
        SceneManager.LoadScene("currentRunStats", LoadSceneMode.Additive);
    }
    void Start()
    {
        UI = GameObject.FindWithTag("GameplayStatsUI");
        currWaveUI = UI.transform.GetChild(0).gameObject;
        currHealthUI = UI.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        currWaveUI.GetComponent<TextMeshProUGUI>().text = "Current Wave: " + GetComponent<PlayerStats>().currentWave;
        currHealthUI.GetComponent<TextMeshProUGUI>().text = "Health: " + GetComponent<PlayerStats>().currentHealth;
    }
}
