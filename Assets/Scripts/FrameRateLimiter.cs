using UnityEngine;

// Could this just be a static class?
public class FrameRateLimiter : MonoBehaviour
{
    public int targetFrameRate = 60;
    
    public bool vSync;

    private void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        QualitySettings.vSyncCount = vSync ? 1 : 0;
    }
}