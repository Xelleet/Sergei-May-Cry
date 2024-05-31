using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject choosePlayPanel;
    [SerializeField] private GameObject playButton;

    [Header("Useless")]
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource _VERY_SPECIAL_AUDIO;
    [SerializeField] private AudioSource _VERY_UNSPECIAL_AUDIO;
    [SerializeField] private Transform cameraTransform;

    private void Awake()
    {
        if (Random.Range(0, 10) == 5)
        {
            player.GetComponent<Animator>().Play("GoofyAhDance");
            _VERY_SPECIAL_AUDIO.Play();
            Destroy(_VERY_UNSPECIAL_AUDIO);
        FindObjectOfType<Camera>().gameObject.transform.position = cameraTransform.position;
        }
    }

    public void ShowChoosePlayPanel()
    {
        choosePlayPanel.SetActive(!choosePlayPanel.active);
        playButton.SetActive(!playButton.active);
    }

    public void PlayNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlaySavedGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
