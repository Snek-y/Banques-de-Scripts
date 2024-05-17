using UnityEngine;

public class TabloManager : MonoBehaviour
{
    public float smooth = 2.0f;
    public Vector3 openPositionOffset = new Vector3(0, 0, 0);
    public Vector3 closedPositionOffset = new Vector3(0, 0, 0);
    private Vector3 closedPosition;
    private Vector3 openPosition;
    public bool open = false;
    private bool canInteract = false;

    void Start()
    {
        closedPosition = transform.position + closedPositionOffset;
        openPosition = closedPosition + openPositionOffset;
    }

    void Update()
    {
        HandleTabloPosition();

        if (canInteract && Input.GetKeyDown(KeyCode.F1))
        {
            open = !open;
        }
    }

    void HandleTabloPosition()
    {
        if (open)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * smooth);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * smooth);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}