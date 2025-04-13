using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;             

public class MenuController : MonoBehaviour
{
    public void OnStartGameButtonClick()
    {
        Debug.Log("Start Game pressed");
    }

    public void OnSettingsButtonClick()
    {
        Debug.Log("Settings pressed");
    }

    public void OnExitButtonClick()
    {
        Debug.Log("Exit pressed");
    }
}
