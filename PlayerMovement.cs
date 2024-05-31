using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //public PlayerData PlayerData;

    [SerializeField] internal float speed = 7f;

    internal float x;
    internal float z;

    private Rigidbody rb;

    [SerializeField] internal float coolDown;

    Vector3 moveVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //transform.position = PlayerData.PlayerPosition;

        if (!PlayerPrefs.HasKey("x")) return;

        transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
    }

    private void FixedUpdate()
    {
        Debug();
    }

    public void Move()
    {
        x = Input.GetAxis("Vertical") * speed / 6;
        z = Input.GetAxis("Horizontal") * speed / 6;

        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.LeftShift)) speed = 7f;
        else speed = 3f;

        moveVector = new Vector3(moveX, rb.velocity.y, moveZ);

        rb.velocity = moveVector;
    }

    public void PlayerRotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y - 90, 0), 0.2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 180, 0), 0.2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 90, 0), 0.2f);
        }
    }

    private void Debug()
    {
        if (Input.GetKeyDown(KeyCode.J))
        { 
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DangerZone"))
        {
            GetComponent<PlayerHealthManager>().ChangeHealth(other.GetComponent<DangerZone>().damage * Time.deltaTime);
        }
    }
}
