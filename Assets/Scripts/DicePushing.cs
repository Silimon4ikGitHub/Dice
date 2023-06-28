using Photon.Pun;
using UnityEngine;

public class DicePushing : MonoBehaviour
{
    [SerializeField] private Vector3 pushDirrection;
    [SerializeField] private Vector3 myPosition;
    [SerializeField] private Vector3 screenMousePosition;
    [SerializeField] private Vector3 worldMousePosition;
    [SerializeField] private Vector3 centerPosition;
    [SerializeField] private float offsetZ;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float forceX;
    [SerializeField] private float forceY;
    [SerializeField] private float forceZ;
    [SerializeField] private float AxisX;
    [SerializeField] private float AxisY;
    [SerializeField] private float PushForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isTaken = false;

    [SerializeField] private Rigidbody myRb;
    [SerializeField] private PhotonView viev;
    [SerializeField] private PhotonTransformView trView;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        viev = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (isTaken)
        {
            TakeDice();
        }

        AxisX = Input.GetAxis("Mouse X");
        AxisY = Input.GetAxis("Mouse Y");

    }

    private void PushDice(Vector3 dirrection)
    {
        myRb.velocity = dirrection;
    }

    private void OnMouseDown()
    {
             viev.RequestOwnership();
             isTaken = true;
    }

    private void OnMouseUp()
    {
        ThrowDice();
    }

    private void TakeDice()
    {
        transform.position = Vector3.MoveTowards(transform.position, myPosition, speed);
        myRb.isKinematic = true;
        screenMousePosition = Input.mousePosition;
        screenMousePosition.z = Camera.main.nearClipPlane;
        worldMousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition) - centerPosition;
        myPosition.z = worldMousePosition.z * offsetZ;
        myPosition.x = worldMousePosition.x * offsetX;
        myPosition.y = worldMousePosition.y * offsetY;
    }

    private void ThrowDice()
    {
        isTaken = false;
        var random = Random.Range(-PushForce, PushForce);
        pushDirrection = new Vector3(AxisX * PushForce, 0, AxisY * PushForce);
        myRb.isKinematic = false;
        PushDice(pushDirrection);
    }
}
