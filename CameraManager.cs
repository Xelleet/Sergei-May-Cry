using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float offsetX = 0f;
    [SerializeField] private float offsetZ = 5f;

    [SerializeField] private GameObject player;

    [SerializeField] private float playerVelocity = 5f;

    private float movementX;
    private float movementZ;

    private void Update()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x));
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z));
        this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));
    }
}
