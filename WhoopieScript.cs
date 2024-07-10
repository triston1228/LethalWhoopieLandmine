using System;
using System.Collections.Generic;
using System.Text;
using Unity.Netcode;
using UnityEngine;

namespace WhoopieLandMine
{
    internal class WhoopieScript : MonoBehaviour
    {

        public Vector3 whoopiePos;


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
            Landmine.SpawnExplosion(whoopiePos, true, 2, 10, 50, 5, null, false);
        }
    }
}
