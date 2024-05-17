using UnityEngine;
using TMPro;

public class RubyBleu : MonoBehaviour
{
    public TextMeshProUGUI ScoreUI;

    public int rubyCount;

    private void Update()
    {
        ScoreUI.text = "" + rubyCount;
    }
}
