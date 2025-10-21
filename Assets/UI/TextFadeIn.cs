using UnityEngine;

public class TextFadeIn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CanvasGroup>().alpha < 1)
        {
            GetComponent<CanvasGroup>().alpha += 0.1f * Time.deltaTime;
        }
    }
}
