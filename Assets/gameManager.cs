using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenuCanvas;
    [SerializeField] GameObject CreditsCanvas;
    [SerializeField] GameObject OptionsCanvas;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ScorePPText;

    [SerializeField] AudioSource audioSource;

    [SerializeField] Slider volSlider;

    int ScoreCount = 0;

    int ScorePlusPlus = 0;

    public void Start()
    {
        MainMenuCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
        OptionsCanvas.SetActive(false);
    }


    public void addPoints(int points)
    {
        Debug.Log("granting free points");
        ScoreCount += points;
        ScoreText.text = "Score: " + (ScoreCount).ToString(); 
    }

    public void goToMainMenu()
    {
        Debug.Log("Going to main menu");
        MainMenuCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
        OptionsCanvas.SetActive(false);
    }

    public void goToCredits()
    {
        Debug.Log("Going to credits");
        MainMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void goToOptions()
    {
        Debug.Log("Going to options");
        MainMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game :(");
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void setVolume()
    {
        Debug.Log("Set volume to " + volSlider.value.ToString());
        audioSource.volume = volSlider.value;
    }

    public void sacrificePoints(int points)
    {
        if (ScoreCount - points >= 0)
        {
            ScoreCount -= points;
            ScoreText.text = "Score: " + (ScoreCount).ToString();

            ScorePlusPlus++;
            ScorePPText.text = "SCORE++: " + (ScorePlusPlus).ToString();
        }

        

    }

}
