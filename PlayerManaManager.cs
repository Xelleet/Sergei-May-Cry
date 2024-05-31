using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaManager : MonoBehaviour
{
    [SerializeField] internal float mana = 100f;

    [SerializeField] internal float manaReducer = 5f;

    [SerializeField] private Image manaImage;

    [SerializeField] internal GameObject checkPoint;

    private void FixedUpdate()
    {
        if (mana > 100) mana = 100;
        if (mana < 0) mana = 0;

        manaImage.fillAmount = mana / 100;

        SetCheckPoint();
    }

    private void SetCheckPoint()
    {
        if (Input.GetKeyDown(KeyCode.F) && mana == 100)
        {
            mana -= 100;

            string checkPointName = "CheckPoint(Clone)";
            PlayerPrefs.DeleteKey(checkPointName);

            Instantiate(checkPoint, transform.position, transform.rotation);
        }
    }

    public void ChangeMana(float count)
    {
        mana += count;
    }

    public IEnumerator ChangeMana(float count, float duration)
    {
        for (int i = 0; i < duration; i++)
        {
            mana += count;
            yield return new WaitForSeconds(duration / 4);
        }
    }
}
