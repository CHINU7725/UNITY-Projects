using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;



public class PlayerGunSelector : MonoBehaviour
{
    [SerializeField] private GunType Gun;


    [SerializeField] private ParticleSystem bloodEffect;
    public ShootConfiguationScriptableObjects ShootConfig;
    public TrailConfigScriptableObjects TrailConfig;

    private float LastShootTime;
    private ParticleSystem ShootSystem;
    private ObjectPool<TrailRenderer> TrailPool;

    Vector3 shootDirection;

    public AudioSource asso;

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

    private void Update()
    {
        shootDirection = ShootSystem.transform.forward;

        Debug.DrawRay(ShootSystem.transform.position, shootDirection * 120f, Color.red);
    }
    public void Shoot()
    {
  
        if (Time.time > ShootConfig.fireRate + LastShootTime)
        {
            LastShootTime = Time.time;
          

            ShootSystem.Play();
            asso.Play();
    
                // If no target is provided, shoot in the forward direction of the ShootSystem
           
          
        
        if (Physics.Raycast(ShootSystem.transform.position, shootDirection, out RaycastHit hit, float.MaxValue, ShootConfig.HitMask))
            {
      
                StartCoroutine(PlayTrail(ShootSystem.transform.position, hit.point, hit));
            }
            else
            {

                RaycastHit Hit = new RaycastHit();
                StartCoroutine(PlayTrail(ShootSystem.transform.position, ShootSystem.transform.position + (shootDirection * TrailConfig.MissDistance), Hit));
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
        ParticleSystem op=new ParticleSystem();
        if(Hit.collider!=null)
        {
           op= Instantiate(bloodEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
        }

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

     /*   if (Hit != null)
        {
            SurfaceManager
        }*/

        yield return new WaitForSeconds(TrailConfig.Duration);
        yield return null;
        instance.emitting = false;
        instance.gameObject.SetActive(false);
        asso.Stop();
        Destroy(op);
        TrailPool.Release(instance);
    }
    private TrailRenderer CreateTrail()
    {
        GameObject instance = new GameObject("Bullet Trail");
        instance.tag = "Bullet";
        instance.layer = 6;
        BoxCollider boxCollider;
        boxCollider = instance.AddComponent<BoxCollider>();
        Rigidbody rigidbody = instance.AddComponent<Rigidbody>();
        rigidbody.useGravity=false;
        boxCollider.size = new Vector3(0.1f, 0.1f, 0.1f);

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