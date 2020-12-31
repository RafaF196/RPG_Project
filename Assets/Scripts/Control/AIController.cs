using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 10f;

        private void Update()
        {
            if (DistanceToPlayer() < chaseDistance)
            {
                // Chase
            }
        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            Vector3.Distance(player.transform.position, transform.position);
        }
    }
}
