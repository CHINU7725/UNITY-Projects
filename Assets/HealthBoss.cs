using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    public int myHealth=30;
    public ProgressBar progressBar;
    public bool isDead=false;
    // Update is called once per frame
    IEnumerator iamDied()
    {
        yield return new WaitForSeconds(1f);
       /* this.gameObject.SetActive(false);*/
        isDead = true;

        GameObject cameraParent = GameObject.FindGameObjectWithTag("Camera");
        cameraParent.transform.GetChild(0).gameObject.SetActive(true);
        cameraParent.transform.GetChild(1).gameObject.SetActive(false);

    }

    public void karoKamal()
    {
        myHealth--;
       
        progressBar.SetProgress(myHealth / 30, 3);
        if (myHealth == 0)
        {
            this.GetComponent<AudioSource>().Play();
            this.gameObject.tag = "Untagged";
            this.GetComponent<Animator>().SetTrigger("7");
            StartCoroutine(iamDied());
        }
    }
}
