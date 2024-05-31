using UnityEngine.Playables;
using UnityEngine;

public class CutSceneTest : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cutScene.Play();
            Destroy(gameObject);
        }
    }
}
