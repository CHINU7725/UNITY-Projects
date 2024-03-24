using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

public class StartFire : MonoBehaviour
{
    public AudioSource audio;
    private GameObject primaryCamera;
    private GameObject joystickCanvas;
    List<Transform> playerTransforms = new List<Transform>();
    private Coroutine shootingCoroutine;

    private void Start()
    {
        primaryCamera = GameObject.FindGameObjectWithTag("Camera");
        joystickCanvas = GameObject.FindGameObjectWithTag("Joystick");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            disableRun();
            playerTransforms = GetValidChildTransforms(other.gameObject, "Pos");

            if (shootingCoroutine != null)
                StopCoroutine(shootingCoroutine);

            shootingCoroutine = StartCoroutine(ShootForDuration());

            if(CurrentNum.characterNum<CurrentNum.EnemiesCount)
            {
                audio.Stop();
            }
        }
        //enableRun();
    }

    IEnumerator ShootForDuration()
    {
        float timer = 0f;
        float duration = 4f;
        audio.Play();// Duration to shoot for in seconds

        while (timer < duration)
        {
            for (int i = 0; i < playerTransforms.Count; i++)
            {
                Transform playerChild = GetValidChild(playerTransforms[i]);
                playerChild.GetComponent<PlayerGunSelector>().Shoot(CurrentNum.LookCouple[playerChild.gameObject]);
            }

            // Wait for the next frame
            yield return null;
            timer += Time.deltaTime;
        }
        audio.Stop();
        // Coroutine finished, reset the shooting coroutine reference
        shootingCoroutine = null;
    }

    public List<Transform> GetValidChildTransforms(GameObject parent, string nameStartsWith)
    {
        List<Transform> validTransforms = new List<Transform>();

        foreach (Transform child in parent.transform)
        {
            if (child.name.StartsWith(nameStartsWith) && child.childCount > 0)
            {
                validTransforms.Add(child);
            }
        }

        return validTransforms;
    }

    public Transform GetValidChild(Transform parent)
    {
        if (parent != null && parent.childCount > 0)
            return parent.GetChild(0);
        else
            return null;
    }



    public void disableRun()
    {
        primaryCamera.SetActive(false);
        joystickCanvas.SetActive(true);
        foreach (Transform t in playerTransforms)
        {
            t.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Idle", true);
        }

        GameObject[] objectsToEnable = GameObject.FindGameObjectsWithTag("Bridge");
        this.GetComponentInParent<Plane>().enabled = false;
        


        foreach (GameObject obj in objectsToEnable)
        {
            obj.GetComponent<Plane>().enabled = false;
        }
    }

    public void enableRun()
    {
        primaryCamera.SetActive(true);
        joystickCanvas.SetActive(false);
        foreach (Transform t in playerTransforms)
        {
            t.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Idle", false);
        }

        GameObject[] objectsToEnable = GameObject.FindGameObjectsWithTag("Bridge");
        this.GetComponentInParent<Plane>().enabled = true;


        foreach (GameObject obj in objectsToEnable)
        {
            obj.GetComponent<Plane>().enabled = true;
        }
    }
}
