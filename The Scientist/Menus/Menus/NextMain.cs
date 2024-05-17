using UnityEngine;

public class NextMain : MonoBehaviour
{
    public GameObject uiElementToActivate; // Référence à l'élément UI à activer                                        

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Next();
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            Next();
        }
    }

    public void Next()
    {
        if (uiElementToActivate != null)
        {
            // Activez l'élément UI
            uiElementToActivate.SetActive(true);
        }
    }
}
