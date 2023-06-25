using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{


    public event EventHandler<OnIngredienAddedEventArgs> OnIngredienAdded;
    public class OnIngredienAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;


    private List<KitchenObjectSO> kitchenObjectSOList;

    public void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //Not a valid ingredient
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //Already has this type
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);


            OnIngredienAdded?.Invoke(this, new OnIngredienAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });
            return true;
        }
    }
}
