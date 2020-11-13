﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class TriggerScript : MonoBehaviour
    {
        public PlayerIndexManager pIndexManager;
        public Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerIndex player = PlayerIndex.ONE;
            PlayerIndexManager avtscr = null;
            avtscr = other.transform.parent.GetComponent<PlayerIndexManager>();
            if (avtscr != null)
            {
                switch (pIndexManager.playerIndex)
                {
                    case PlayerIndex.ONE:

                        //if (other.gameObject.tag == "Player2")
                        if (avtscr.playerIndex == PlayerIndex.TWO)
                        {
                            player = PlayerIndex.TWO;
                            rb.AddForce(transform.forward * 12.5f);
                            Debug.Log("Force");
                        }
                        break;
                    case PlayerIndex.TWO:
                        //if (other.gameObject.tag == "Player1")
                        if (avtscr.playerIndex == PlayerIndex.ONE)
                        {
                            player = PlayerIndex.ONE;
                        }
                        break;
                    default:

                        break;
                }
                Debug.Log("Soy " + pIndexManager.playerIndex + " y toqué al " + player);
                pIndexManager.TouchedOtherPlayer(player);
            }
        }
    }
}