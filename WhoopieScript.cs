using System;
using System.Collections.Generic;
using System.Text;
using Unity.Netcode;
using UnityEngine;

namespace WhoopieLandMine
{
    internal class WhoopieScript : MonoBehaviour
    {

        private Vector3 whoopiePos;
        private GameObject parentWhoopieCushion;
        
        private bool explosionEffect;
        private float killRange;
        private float damageRange;
        private int nonLethalDamage;
        private float physicsForce;
        private bool goThroughCar;

        
        private void Awake()
        {

            explosionEffect = WhoopieLandMine.Instance.explosionEffectConfig.Value;
            goThroughCar = WhoopieLandMine.Instance.goThroughCarConfig.Value;

            killRange = WhoopieLandMine.Instance.killRangeConfig.Value;
            damageRange = WhoopieLandMine.Instance.damageRangeConfig.Value;
            physicsForce = WhoopieLandMine.Instance.physicsForceConfig.Value;

            nonLethalDamage = WhoopieLandMine.Instance.nonLethalDamageConfig.Value;

        }
        private void Start()
        {
            parentWhoopieCushion = transform.parent.gameObject;
        }
        private void Update()
        {
            whoopiePos = transform.position;

        }

        void OnEnable()
        {
            WhoopieCushionTriggerPatch.OnWhoopieTrigger += WhoopieCushionTriggerPatch_OnWhoopieTrigger;
        }

        private void WhoopieCushionTriggerPatch_OnWhoopieTrigger(object sender, WhoopieEventArgs e)
        {
            Debug.Log("Explode");
            Landmine.SpawnExplosion(whoopiePos, explosionEffect, killRange, damageRange, nonLethalDamage, physicsForce, null, goThroughCar);
            Destroy(parentWhoopieCushion.gameObject);
        }
    }
}
