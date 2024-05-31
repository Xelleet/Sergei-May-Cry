using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private float stamina = 10f;
    [SerializeField] private Image staminaImage;

    [SerializeField] internal bool isBlocked = false;

    private void Update()
    {
        ToBlock();
    }

    private void FixedUpdate()
    {
        staminaImage.fillAmount = stamina / 10f;
    }

    private void ToBlock()
    {
        if (stamina <= 0)
        {
            isBlocked = false;
            StopCoroutine(Block());
            return;
        }
        //{
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isBlocked = true;
                StartCoroutine(Block());
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                isBlocked = false;
                StopCoroutine(Block());
            }
        //}
        //else
        //{
        //    isBlocked = false;
        //    StopCoroutine(Block());
        //    StartCoroutine(Recovery());
        //}
    }

    public IEnumerator Block()
    {
        while (isBlocked)
        {
            stamina -= 1f;
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Recovery()
    {
        //while (stamina < 10)
        //{
            stamina += 1f;
            yield return new WaitForSeconds(1f);
        //}
    }
}
