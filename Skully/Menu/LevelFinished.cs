using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    public RubyBleu rubyBleu;

    public TextMeshProUGUI rubyBleuText;

    public string sceneName;

    public void Update()
    {
        rubyBleuText.text = "Ruby : " + rubyBleu.rubyCount;
        rubyBleuText.color = Color.blue;

    }

    public void NextButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}