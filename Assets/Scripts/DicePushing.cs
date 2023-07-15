using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] private GameObject diceSpawner;
    [SerializeField] private GameObject diceLeavePoint;
    [SerializeField] private PhotonView viev;
    [SerializeField] private PhotonTransformView trView;
    //[SerializeField] private TextMeshProUGUI tmp;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        viev = GetComponent<PhotonView>();
        diceSpawner = GameObject.FindGameObjectWithTag("DiceSpawner");
        diceLeavePoint = GameObject.FindGameObjectWithTag("LeavePoint");
    }

    void FixedUpdate()
    {
        if (isTaken)
        {
            TakeDice();
        }

        if (transform.position.y < diceLeavePoint.transform.position.y)
        {
            ReloadDice();
        }
        //To SHOW THE AXIS SPEED ON DISPLAY
        //tmp.text = AxisX.ToString();
    }

    private void PushDice(Vector3 dirrection)
    {
        myRb.AddForce(dirrection, ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
       viev.RequestOwnership();
       isTaken = true;
    }

    private void OnMouseUp()
    {
        ThrowDice();
        viev.RequestOwnership();
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
        AxisX = Input.GetAxis("Mouse X");
        AxisY = Input.GetAxis("Mouse Y");

        isTaken = false;
        var random = Random.Range(-PushForce, PushForce);
        pushDirrection = new Vector3(AxisX * PushForce, 0, AxisY * PushForce);
        myRb.isKinematic = false;
        PushDice(pushDirrection);
    }

    private void ReloadDice()
    {
        transform.position = diceSpawner.transform.position;
    }
}
