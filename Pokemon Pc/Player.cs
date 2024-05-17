using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Référence au parent des boutons
    public Transform AttackButtonParent;

    public Attack[] PossiblesAttacks;

    public TextMeshProUGUI playerName;

    public Color playerColor;

    public GameManager gameManager;
}
