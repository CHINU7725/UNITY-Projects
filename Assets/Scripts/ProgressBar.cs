using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image ProgressImage;
    [SerializeField] private float DefaultSpeed = 1f;
    [SerializeField] private UnityEvent<float> Onprogress;
    [SerializeField] UnityEvent OnCompleted;
    private Coroutine AnimationCoroutine;

    private void Start()
    {
        if(ProgressImage.type != Image.Type.Filled)
        {
            Debug.Log("NOT FILLED!!!!");
            this.enabled = false;
        }
    }

    public void SetProgress(float Progress)
    {
        SetProgress(Progress, DefaultSpeed);
    }

    public void SetProgress(float Progress, float Speed)
    {
        if (Progress<0 || Progress >1)
        {
            Progress = Mathf.Clamp01(Progress);
        }
        if(Progress != ProgressImage.fillAmount)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);   
            }
            AnimationCoroutine = StartCoroutine(AnimateProgress(Progress, Speed));
        }
    }
    private IEnumerator AnimateProgress (float Progress, float Speed)
    {
        float time = 0;
        float initialProgress = ProgressImage.fillAmount;
        while (time < 1)
        {
            ProgressImage.fillAmount = Mathf.Lerp(initialProgress, Progress, time);
            time += Time.deltaTime*Speed;

            Onprogress?.Invoke(ProgressImage.fillAmount);
            yield return null;
        }

        ProgressImage.fillAmount = Progress;
        Onprogress?.Invoke(Progress);
        OnCompleted?.Invoke(); 
    }
}
