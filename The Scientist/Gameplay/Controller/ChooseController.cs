using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ChooseController : MonoBehaviour
{
    public ChooseLabelController label;
    public GameController gameController;
    private RectTransform rectTransform;
    private Animator animator;
    private float labelHeight = -1;


    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ChooseScene scene)
    {
        DestroyLabels();
        animator.SetTrigger("Show");
        for(int index = 0;  index < scene.Labels.Count; index++) 
        {
            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();

            if(labelHeight == -1 ) 
            { 
                labelHeight = newLabel.GetHeight();
            }

            newLabel.Setup(scene.Labels[index], this, CalculateLabelPosition(index, scene.Labels.Count));
        }

        Vector2 size = rectTransform.sizeDelta;
        size.y = (scene.Labels.Count + 2) * labelHeight;
        rectTransform.sizeDelta = size;
    }

    public void PerformChoose(StoryScene scene)
    {
        gameController.PlayScene(scene);
        animator.SetTrigger("Hide");
    }

    private float CalculateLabelPosition(int labelIndex, int labelCount)
    {
        if(labelCount %2 == 0)
        {
            if(labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex - 1) + labelHeight / 2;
            }
            else
            {
                return - 1 * (labelHeight * (labelIndex - labelCount / 2) + labelHeight / 2);
            }
        }
        else
        {
            if (labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex - 1) + labelHeight / 2;
            }
            else if (labelIndex > labelCount / 2)
            {
                return -1 * (labelHeight * (labelIndex - labelCount / 2));
            }
            else
            {
                return 0;
            }
        }
    }

    private void DestroyLabels()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
