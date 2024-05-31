using UnityEngine;

public class FPS : MonoBehaviour
{
    private GUIStyle style = new GUIStyle();

    private int accumulator = 0;
    private int counter = 0;
    private float timer = 0f;

    private void Awake()
    {
        style.normal.textColor = Color.white;
        style.fontSize = 32;
        style.fontStyle = FontStyle.Bold;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 34), "FPS: " + counter, style);
    }

    private void Update()
    {
        accumulator++;
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            counter = accumulator;
            accumulator = 0;
        }
    }
}
