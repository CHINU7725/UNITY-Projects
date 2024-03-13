using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering.Universal;


public class PlayerGunSelector : MonoBehaviour
{
    [SerializeField] private GunType Gun;
    /*    [SerializeField] private Transform GunParent;*/
    public ShootConfiguationScriptableObjects ShootConfig;
    public TrailConfigScriptableObjects TrailConfig;

    private MonoBehaviour ActiveMonoBehaviour;
    private GameObject Model;
    private float LastShootTime;
    private ParticleSystem ShootSystem;
    private ObjectPool<TrailRenderer> TrailPool;

    public GameObject gune;
    public void Start()
    {        LastShootTime = 0;
        TrailPool = new ObjectPool<TrailRenderer>(CreateTrail);
        /*        Debug.Log(ModelPrefab);
                Model = Instantiate(ModelPrefab);
                Model.transform.SetParent(Parent, false);
                Model.transform.localPosition = SpawnPoint;
                Model.transform.localRotation = Quaternion.Euler(SpawnRotation);*/
        ShootSystem = gune.GetComponentInChildren<ParticleSystem>();

    }

    public void Shoot(GameObject target)
    {
  
        if (Time.time > ShootConfig.fireRate + LastShootTime)
        {
            LastShootTime = Time.time;
            Debug.Log("Raghav");

            ShootSystem.Play();

            Vector3 shootDirection;

            if (CurrentNum.enemyPosition!=Vector3.up)
            {
                // Calculate the direction towards the target
                shootDirection = (target.transform.position - ShootSystem.transform.position).normalized;
            }
            else
            {
                // If no target is provided, shoot in the forward direction of the ShootSystem
                shootDirection = -ShootSystem.transform.forward;
            }

            if (Physics.Raycast(ShootSystem.transform.position, shootDirection, out RaycastHit hit, float.MaxValue, ShootConfig.HitMask))
            {
                StartCoroutine(PlayTrail(ShootSystem.transform.position, hit.point, hit));
            }
            else
            {
                StartCoroutine(PlayTrail(ShootSystem.transform.position, ShootSystem.transform.position + (shootDirection * TrailConfig.MissDistance), new RaycastHit()));
            }
        }
    }

    private IEnumerator PlayTrail(Vector3 StartPoint, Vector3 EndPoint, RaycastHit Hit)
    {
        TrailRenderer instance = TrailPool.Get();
        instance.gameObject.SetActive(true);
        instance.transform.position = StartPoint;
        yield return null; // avoid position carry-over from last frame if reused

        instance.emitting = true;

        float distance = Vector3.Distance(StartPoint, EndPoint);
        float remainingDistance = distance;
        while (remainingDistance > 0)
        {
            instance.transform.position = Vector3.Lerp(
                StartPoint,
                EndPoint,
                Mathf.Clamp01(1 - (remainingDistance / distance))
            );
            remainingDistance -= TrailConfig.SimulationSpeed * Time.deltaTime;

            yield return null;
        }
        instance.transform.position = EndPoint;
        yield return new WaitForSeconds(TrailConfig.Duration);
        yield return null;
        instance.emitting = false;
        instance.gameObject.SetActive(false);
        TrailPool.Release(instance);
    }
    private TrailRenderer CreateTrail()
    {
        GameObject instance = new GameObject("Bullet Trail");
        TrailRenderer trail = instance.AddComponent<TrailRenderer>();
        trail.colorGradient = TrailConfig.Color;
        trail.material = TrailConfig.Material;
        trail.widthCurve = TrailConfig.WidthCurve;
        trail.time = TrailConfig.Duration;
        trail.minVertexDistance = TrailConfig.MinVertexDistance;

        trail.emitting = false;
        trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        return trail;
    }



}