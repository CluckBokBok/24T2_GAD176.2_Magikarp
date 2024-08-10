using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GAD176_ItemPickup_Base
{ 
public class ItemPickupFollow : ItemPickupMain
    {

    [SerializeField] private Vector2 followOffset = new Vector2(1.5f, 1);
    private bool isFollowingPlayer = false;
    [SerializeField] private float bounceAmplitude = 0.3f; 
    [SerializeField] private float bounceFrequency = 10f;
    private float bounceTimer = 0f;
    private ItemPickupTextManager itemPickupTextManager;


        // Start is called before the first frame update
        void Start()
    {
            base.Start();
            itemPickupTextManager = FindObjectOfType<ItemPickupTextManager>();  // Find the ItemPickupTextManager in the scene
            if (itemPickupTextManager == null)
            {
                Debug.LogError("ItemPickupTextManager not found!");
            }
        }

    // Update is called once per frame
    public void Update()
    {

        base.Update();

        if (!isFollowingPlayer && playerLocation != null && pickupItemRB != null)
        {
            MoveTowardPlayer(playerLocation.position);
        }
        else if (isFollowingPlayer && playerLocation != null)
        {
            FollowPlayerWithBounce();
        }
    }

    private void FollowPlayerWithBounce()
        {
            
            bounceTimer += Time.deltaTime * bounceFrequency;

            float bounceOffset = Mathf.Sin(bounceTimer) * bounceAmplitude;

            Vector2 targetPosition = (Vector2)playerLocation.position + followOffset;
            targetPosition.y += bounceOffset;

            transform.position = targetPosition;

            if (!isFollowingPlayer)
            {
                UIPopup();

            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(playerTag))
            {
                isFollowingPlayer = true;
                transform.SetParent(playerLocation);
                pickupItemRB.isKinematic = true;
                Debug.Log("You have a follower!");

                
            }
        }
        private void UIPopup()
        {
            if (itemPickupTextManager != null)
            {
                itemPickupTextManager.ShowPopup("You have acquired a follower!", 3f); 
            }
        }


    }
}