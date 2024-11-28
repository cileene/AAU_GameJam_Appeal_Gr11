using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoadManager : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("CourtroomScene");
    }
}
