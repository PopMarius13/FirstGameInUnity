using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject PozIni;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            CharacterController cc = other.GetComponent<CharacterController>();
            if(cc != null)
            {
                cc.enabled = false;
            }
            StartCoroutine(ccEnable(cc));
            other.transform.position = PozIni.transform.position;
        }
    }

    IEnumerator ccEnable (CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
