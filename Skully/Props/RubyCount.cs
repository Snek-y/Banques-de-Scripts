using TMPro;
using UnityEngine;

public class RubyCount : MonoBehaviour
{
    public RubyBleu rubyBleu;

    public TextMeshProUGUI rubyBleuText;

    public void Update()
    {
        rubyBleuText.text = "" + rubyBleu.rubyCount;
        rubyBleuText.color = Color.white;

    }
}
