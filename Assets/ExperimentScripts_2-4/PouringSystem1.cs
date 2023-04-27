using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringSystem1 : MonoBehaviour
{
    private LiquidSystem1 liquidSystem;
    private ParticleSystem pouringPS;
    private List<ParticleCollisionEvent> collisionEvents;
    [Tooltip("ML per single particle. This is calculated automatically by the Pour Per Second & Rate Over Time in LiquidSystemV2.")]
    public float mlpp = 0; // ML Per Particle
    public int colls = 0;
    [SerializeField] float molar;

    private void Start()
    {
        liquidSystem = transform.parent.GetComponent<LiquidSystem1>();
        pouringPS = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

        //mlpp = liquidSystem.pourPerSecond / pouringPS.emission.rateOverTime.constant;
        mlpp = liquidSystem.pourPerSecond; // Changed to this because we will be using it as pour per particle instead of sec
    }
    private void OnParticleCollision(GameObject other)
    {
        int totalCollisions = pouringPS.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        // Debug.Log(i);

        while (i < totalCollisions)
        {
            if (collisionEvents[i].colliderComponent.CompareTag("Liquid"))
            {
                collisionEvents[i].colliderComponent.transform.parent.SendMessage("Fill", mlpp, SendMessageOptions.DontRequireReceiver);
                DetectHCl.ChangeEmission(0.5f);

                // collisionEvents[i].colliderComponent.transform.parent.SendMessage("calculateMolar", molar, SendMessageOptions.DontRequireReceiver);
                colls++;
            }
            i++;
            // Debug.Log(i);
        }
    }
    //private void OnParticleTrigger()
    //{

    //    //Get all particles that entered a box collider
    //    List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
    //    int enterCount = pouringPS.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enteredParticles);

    //    if (enterCount > 0)
    //    {

    //        GetComponent<ParticleSystem>().trigger.GetCollider(0).gameObject.transform.parent.SendMessage("Fill", mlpp, SendMessageOptions.DontRequireReceiver);

    //        DetectHCl.ChangeEmission(1);

    //    }

    //}
}
