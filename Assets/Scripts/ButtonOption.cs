using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOption : MonoBehaviour
{

    public void TrackSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Track01()
    {
        SceneManager.LoadScene(2);
    }

    public void Track02()
    {
        SceneManager.LoadScene(3);
    }

    public void Track03()
    {
        SceneManager.LoadScene(4);
    }
}
