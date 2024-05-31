using UnityEngine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private PlayableDirector cutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cutScene.Play();
        }
    }

    public void EndCutscene()
    {
        Destroy(camera);
    }
}
