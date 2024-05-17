using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform ButtonParent;

    public TextMeshProUGUI TurnText;

    public Player player;
    public Ennemi ennemi;

    public EnnemiHealth ennemiHealth;
    public PlayerHealth playerHealth;

    private int currentAttack;

    public void NormalButton(int attackIndex)
    {
        if (ButtonParent != null)
        {
            StartCoroutine(Normal());
        }
        
        currentAttack = attackIndex;
    }

    public IEnumerator Normal()
    {
        ButtonParent.gameObject.SetActive(false);
        TurnText.gameObject.SetActive(true);
        TurnText.text = "Nidorino utilise : " + player.PossiblesAttacks[currentAttack].Name;

        if(ennemiHealth != null)
        {
            ennemiHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        currentAttack = Random.Range(0, 4);
        TurnText.text = "Ectoplasma utilise : " + ennemi.PossiblesAttacks[currentAttack].Name;

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        TurnText.gameObject.SetActive(false);
        ButtonParent.gameObject.SetActive(true);
    }

    public void PoisonButton(int attackIndex)
    {
        if(ButtonParent != null)
        {
            StartCoroutine(Poison());
        }

        currentAttack = attackIndex;
    }

    public IEnumerator Poison()
    {
        ButtonParent.gameObject.SetActive(false);
        TurnText.gameObject.SetActive(true);
        TurnText.text = "Nidorino utilise : " + player.PossiblesAttacks[currentAttack].Name;

        if (ennemiHealth != null)
        {
            ennemiHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        currentAttack = Random.Range(0, 4);
        TurnText.text = "Ectoplasma utilise : " + ennemi.PossiblesAttacks[currentAttack].Name;

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        TurnText.gameObject.SetActive(false);
        ButtonParent.gameObject.SetActive(true);
    }

    public void FlyButton(int attackIndex)
    {
        if(ButtonParent != null)
        {
            StartCoroutine(Fly());
        }

        currentAttack = attackIndex;
    }

    public IEnumerator Fly()
    {
        ButtonParent.gameObject.SetActive(false);
        TurnText.gameObject.SetActive(true);
        TurnText.text = "Nidorino utilise : " + player.PossiblesAttacks[currentAttack].Name;

        if (ennemiHealth != null)
        {
            ennemiHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        currentAttack = Random.Range(0, 4);
        TurnText.text = "Ectoplasma utilise : " + ennemi.PossiblesAttacks[currentAttack].Name;

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        TurnText.gameObject.SetActive(false);
        ButtonParent.gameObject.SetActive(true);
    }

    public void FightingButton(int attackIndex)
    {
        if(ButtonParent !=null)
        {
            StartCoroutine(Fighting());
        }

        currentAttack = attackIndex;
    }

    public IEnumerator Fighting()
    {
        ButtonParent.gameObject.SetActive(false);
        TurnText.gameObject.SetActive(true);
        TurnText.text = "Nidorino utilise : " + player.PossiblesAttacks[currentAttack].Name;

        if (ennemiHealth != null)
        {
            ennemiHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        currentAttack = Random.Range(0, 4);
        TurnText.text = "Ectoplasma utilise : " + ennemi.PossiblesAttacks[currentAttack].Name;

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(2);
        }

        yield return new WaitForSeconds(3);
        TurnText.gameObject.SetActive(false);
        ButtonParent.gameObject.SetActive(true);
    }

    void Start()
    {
        TurnText.gameObject.SetActive(false);
    }
}