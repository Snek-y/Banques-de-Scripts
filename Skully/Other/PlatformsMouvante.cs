using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint; // Point de départ de la plateforme
    public Transform endPoint;   // Point d'arrivée de la plateforme
    public float speed = 2f;     // Vitesse de déplacement de la plateforme

    private Vector3 nextPoint;   // Prochain point de déplacement
    private bool movingToEnd = true; // Booléen pour indiquer si la plateforme se déplace vers le point d'arrivée ou le point de départ

    void Start()
    {
        // Initialisation du premier point de déplacement
        nextPoint = endPoint.position;
    }

    void Update()
    {
        // Déplacement de la plateforme
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);

        // Vérifier si la plateforme a atteint le prochain point
        if (Vector3.Distance(transform.position, nextPoint) < 0.1f)
        {
            // Changer la direction de déplacement
            if (movingToEnd)
            {
                nextPoint = startPoint.position;
            }
            else
            {
                nextPoint = endPoint.position;
            }

            // Inverser la direction de déplacement
            movingToEnd = !movingToEnd;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(startPoint.transform.position, 0.5f);
        Gizmos.DrawWireSphere(endPoint.transform.position, 0.5f);
        Gizmos.DrawLine(startPoint.transform.position, endPoint.transform.position);
    }
}
