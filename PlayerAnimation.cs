using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    //Эти поля нужно было засунуть в скрипт PlayerAttack, но я как-то обосрался и в общем они тут. Не обращайте внимание на них

    [SerializeField] private float currentCoolDown;
    [SerializeField] private float standartCoolDown;

    [SerializeField] internal bool comboIsActive = false;

    [SerializeField] internal Animator anim;

    private void Update()
    {
        currentCoolDown += Time.deltaTime;
    }

    public void SetAnim()
    {
        anim.SetFloat("Speed", GetComponent<PlayerMovement>().x, 0.1f, Time.deltaTime);
        anim.SetFloat("Direction", GetComponent<PlayerMovement>().z, 0.1f, Time.deltaTime);

        anim.SetBool("Idle", GetComponent<PlayerMovement>().x == 0 && GetComponent<PlayerMovement>().z == 0);
        anim.SetBool("IsBlocked", GetComponent<PlayerBlock>().isBlocked);

        if (Input.GetKeyDown(KeyCode.Mouse0) && !GetComponent<PlayerInventory>().isInInventory && currentCoolDown >= standartCoolDown)  //Короче куллдаун я засунул не туда, но уже ничего не поделаешь, так что пофиг
        {
            foreach (var item in Resources.FindObjectsOfTypeAll(typeof(DialogueManager)) as DialogueManager[])
            {
                if (item.dialoguePanel.active) return;
            }

            anim.SetTrigger(GetComponent<PlayerAttack>().currentWeapon.GetComponent<Weapon>().animKey);
            comboIsActive = true;
            currentCoolDown = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && currentCoolDown >= standartCoolDown && comboIsActive)
        {
            anim.SetTrigger("Combo");
            StartCoroutine(StopMove());
            currentCoolDown = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Block");
            //GetComponent<PlayerAttack>().StartCoroutine(GetComponent<PlayerAttack>().Block());
        }

        //if (Input.GetKeyDown(KeyCode.Space)) anim.SetTrigger("Jump");
        if (Input.GetKeyDown(KeyCode.C)) anim.SetTrigger("Crouch");
        if (Input.GetKeyUp(KeyCode.C)) anim.SetTrigger("Up");
        if (Input.GetKeyDown(KeyCode.LeftControl)) anim.SetTrigger("Roll");
    }

    public IEnumerator StopMove()
    {
        yield return new WaitForSeconds(standartCoolDown + 0.2f);
        comboIsActive = false;
    }
}
