using UnityEngine;

public class Opendoor : MonoBehaviour
{
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float DoorCloseAngle = 0.0f;
    public bool open = false;
    public bool enter = false;

    private Quaternion doorOpenRotation;
    private Quaternion doorCloseRotation;

    void Start()
    {
        doorOpenRotation = Quaternion.Euler(0, DoorOpenAngle, 0);
        doorCloseRotation = Quaternion.Euler(0, DoorCloseAngle, 0);
    }

    //Update is called once per frame
    void Update()
    {
        HandleDoorRotation();

        if (enter && Input.GetKeyDown(KeyCode.F2))
        {
            open = !open;
        }
    }

    void HandleDoorRotation()
    {
        Quaternion targetRotation = open ? doorOpenRotation : doorCloseRotation;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enter = false;
        }
    }
}