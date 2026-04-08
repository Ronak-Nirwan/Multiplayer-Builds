using TMPro;
using UnityEngine;

public class FrameRate : MonoBehaviour
{

    public TextMeshProUGUI FPSText;

    private float pollingTime = 0.5f;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.unscaledDeltaTime;
        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            
            FPSText.text = "FPS : " + frameRate;

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
