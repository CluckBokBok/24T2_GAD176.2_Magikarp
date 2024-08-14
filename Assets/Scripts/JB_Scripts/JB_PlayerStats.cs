using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.GAD176.ReusableGameFramework.Player.Stats
{



    public class JB_PlayerStats : MonoBehaviour
    {

        public float playerHealth = 50f;

        public void TakeDamage(int damage)
        {
            playerHealth -= damage;
            Debug.Log($" takes {damage} damage. Health is now {playerHealth}.");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}