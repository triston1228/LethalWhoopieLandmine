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
        
        private bool explosionEffect = true;
        private float killRange = 1f;
        private float damageRange = 10f;
        private int nonLethalDamage = 50;
        private float physicsForce = 5f;
        private bool goThroughCar = false;

        

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
