using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class WaterHoseParticles : MonoBehaviour
    {
        public static float lastSoundTime;
        public float force = 1;


        private List<ParticleCollisionEvent> m_CollisionEvents = new List<ParticleCollisionEvent>();
        private ParticleSystem m_ParticleSystem;


        private void Start()
        {
            m_ParticleSystem = GetComponent<ParticleSystem>();
        }


        private void OnParticleCollision(GameObject other)
        {
            int safeLength = m_ParticleSystem.GetSafeCollisionEventSize();

            if (m_CollisionEvents.Count < safeLength)
            {
                m_CollisionEvents = new List<ParticleCollisionEvent>();
            }

            int numCollisionEvents = m_ParticleSystem.GetCollisionEvents(other, m_CollisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                if (Time.time > lastSoundTime + 0.2f)
                {
                    lastSoundTime = Time.time;
                }

                var col = m_CollisionEvents[i].colliderComponent;

                if (col.GetComponent<Rigidbody>() != null)
                {
                    Vector3 vel = m_CollisionEvents[i].velocity;
                    col.GetComponent<Rigidbody>().AddForce(vel*force, ForceMode.Impulse);
                }

                other.BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);

                i++;
            }
        }
    }
}
