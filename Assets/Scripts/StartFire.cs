using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;
using JetBrains.Annotations;

public class StartFire : MonoBehaviour
{
    public AudioSource audio;
    private GameObject primaryCamera;
    private GameObject joystickCanvas;
    List<Transform> playerTransforms = new List<Transform>();
    private Coroutine shootingCoroutine;
    bool flag;


    private void Start()
    {
        flag = true;
        primaryCamera = GameObject.FindGameObjectWithTag("Camera");
        joystickCanvas = GameObject.FindGameObjectWithTag("Joystick").transform.GetChild(0).gameObject;
        
    }
    private void Update()
    {
        if (CurrentNum.enemies.Count == CurrentNum.EnemyDeadCount && flag)
        {
            enableRun();
            flag = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            playerTransforms = GetValidChildTransforms(other.gameObject, "Pos");
           StartCoroutine(disableRun());

            flag = true ;
            
        }
        //enableRun();
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



    public IEnumerator disableRun()
    {
        primaryCamera.SetActive(false);
        yield return new WaitForSeconds(1.5f);
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


        StartCoroutine(delayAnimation());
    }



    IEnumerator delayAnimation()
    {
               
        primaryCamera.SetActive(true);

        yield return new WaitForSeconds(1.5f);
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
