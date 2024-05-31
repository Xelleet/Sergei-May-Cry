using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;

    [SerializeField] private string _VERY_SPECIAL_ANIM;
    [SerializeField] private AudioSource _VERY_SPECIAL_AUDIO;

    [SerializeField] internal AudioSource dialogueAudio;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate()
    {
        if (!GetComponent<PlayerBlock>().isBlocked)
        {
            playerMovement.Move();
            playerMovement.PlayerRotation();
        }

        playerAnimation.SetAnim();

        VERYSPECIALANIMATION();
    }

    private void VERYSPECIALANIMATION()
    {
        if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.Y) && GetComponent<PlayerManaManager>().mana == 100)
        {
            GetComponent<Animator>().Play(_VERY_SPECIAL_ANIM);
            GetComponent<PlayerManaManager>().ChangeMana(-100);
            StartCoroutine(PlayAudio());
        }
    }

    private IEnumerator PlayAudio()
    {
        _VERY_SPECIAL_AUDIO.Play();
        yield return new WaitForSeconds(15);
        _VERY_SPECIAL_AUDIO.Stop();
    }
}
