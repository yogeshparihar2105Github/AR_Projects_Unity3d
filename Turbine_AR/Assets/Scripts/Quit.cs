using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject quitConfirmationPanel;

    public void ShowQuitConfirmationPanel()
    {
        quitConfirmationPanel.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void CancelQuit()
    {
        quitConfirmationPanel.SetActive(false);
    }

    public void OpenGitHubProfile()
    {
        // Replace "YourGitHubProfileURL" with your actual GitHub profile URL
        string githubURL = "https://github.com/yogeshparihar2105Github";
        Application.OpenURL(githubURL);
    }
    public void OpenLinkedinProfile()
    {
        // Replace "YourGitHubProfileURL" with your actual GitHub profile URL
        string LinkedinURL = "https://www.linkedin.com/in/yogesh-parihar-56a30816b/";
        Application.OpenURL(LinkedinURL);
    }
    public void OpenItch_IOProfile()
    {
        // Replace "YourGitHubProfileURL" with your actual GitHub profile URL
        string itchURL = "https://yogesh00parihar.itch.io/";
        Application.OpenURL(itchURL);
    }
}
