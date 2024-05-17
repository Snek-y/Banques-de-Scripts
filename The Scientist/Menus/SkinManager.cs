using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;

public class ChoixPerso : MonoBehaviour
{
    public SpriteRenderer sc;
    public SpriteRenderer ec;
    public SpriteRenderer hc;
    public SpriteRenderer bc;

    public List<Sprite> HairColor = new List<Sprite>();
    public List<Sprite> BangColor = new List<Sprite>();
    public List<Sprite> EyeColor = new List<Sprite>();
    public List<Sprite> SkinColor = new List<Sprite>();

    private int selectedhaircolor = 0;
    private int selectedbangcolor = 0;
    private int selectedeyecolor = 0;
    private int selectedskincolor = 0;

    public GameObject haircolorchoice;
    public GameObject bangcolorchoice;
    public GameObject eyecolorchoice;
    public GameObject skincolorchoice;

    public GameObject persoMenuUI;// référence au panneau du menu choix personnage
    public GameObject[] HUDElements; // Tableau des éléments du HUD à cacher

    public void OpenNewSkin()
    {
        Time.timeScale = 1f;
        // Affichez le menu choix perso
        persoMenuUI.SetActive(true);

        // Cachez les éléments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(false);
        }
    }

    public void CloseNewSkin()
    {
        // Cachez le menu choix perso
        persoMenuUI.SetActive(false);

        // Affichez les éléments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(true);
        }
    }

    public void NextHairColor()
    {
        selectedhaircolor = selectedhaircolor + 1;
        if (selectedhaircolor == HairColor.Count)
        {
            selectedhaircolor = 0;
        }
        hc.sprite = HairColor[selectedhaircolor];
    }

    public void BackHairColor()
    {
        selectedhaircolor = selectedhaircolor - 1;
        if (selectedhaircolor < 0)
        {
            selectedhaircolor = HairColor.Count - 1;
        }
        hc.sprite = HairColor[selectedhaircolor];
    }

    public void NextBangColor()
    {
        selectedbangcolor = selectedbangcolor + 1;
        if (selectedbangcolor == BangColor.Count)
        {
            selectedbangcolor = 0;
        }
        bc.sprite = BangColor[selectedbangcolor];
    }

    public void BackBangColor()
    {
        selectedbangcolor = selectedbangcolor - 1;
        if (selectedbangcolor < 0)
        {
            selectedbangcolor = BangColor.Count - 1;
        }
        bc.sprite = BangColor[selectedbangcolor];
    }

    public void NextEyeColor()
    {
        selectedeyecolor = selectedeyecolor + 1;
        if (selectedeyecolor == EyeColor.Count)
        {
            selectedeyecolor = 0;
        }
        ec.sprite = EyeColor[selectedeyecolor];
    }

    public void BackEyeColor()
    {
        selectedeyecolor = selectedeyecolor - 1;
        if (selectedeyecolor < 0)
        {
            selectedeyecolor = EyeColor.Count - 1;
        }
        ec.sprite = EyeColor[selectedeyecolor];
    }

    public void NextSkinColor()
    {
        selectedskincolor = selectedskincolor + 1;
        if (selectedskincolor == SkinColor.Count)
        {
            selectedskincolor = 0;
        }
        sc.sprite = SkinColor[selectedskincolor];
    }

    public void BackSkinColor()
    {
        selectedskincolor = selectedskincolor - 1;
        if (selectedskincolor < 0)
        {
            selectedskincolor = SkinColor.Count - 1;
        }
        sc.sprite = SkinColor[selectedskincolor];
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(haircolorchoice, "Assets/selectedhaircolor.prefab");
        PrefabUtility.SaveAsPrefabAsset(bangcolorchoice, "Assets/selectedhaircolor.prefab");
        PrefabUtility.SaveAsPrefabAsset(eyecolorchoice, "Assets/selectedeyecolor.prefab");
        PrefabUtility.SaveAsPrefabAsset(skincolorchoice, "Assets/selectedskincolor.prefab");
        SceneManager.LoadScene("Gameplay");
    }
}