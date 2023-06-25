using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //There is no kitchen object here

            if (player.HasKitchenObject())
            {
                //player carring something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player not carring anything
            }
        }
        else
        {
            //There is not kitchen object here
            if(player.HasKitchenObject())
            {
                //player is carring something
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //Player is not carring Plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //Counter is holding a Plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())){
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                //player is not carring anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}