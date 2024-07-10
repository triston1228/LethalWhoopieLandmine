using System;
using System.Collections.Generic;
using System.Text;
using Unity.Netcode;
using UnityEngine;

namespace WhoopieLandMine
{
    internal class WhoopieScript : NetworkBehaviour
    {

        public Vector3 whoopiePos;
        public WhoopieCushionItem whoopieScript;

        private void Start()
        {
            whoopieScript = GetComponent<WhoopieCushionItem>();
        }
        private void Update()
        {
            whoopiePos = transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!whoopieScript.isHeld && (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy")))
            {
                Debug.Log("Explode");
                Landmine.SpawnExplosion(whoopiePos, true, 2, 10, 50, 5, null, false);
            }

        }

    }
}
