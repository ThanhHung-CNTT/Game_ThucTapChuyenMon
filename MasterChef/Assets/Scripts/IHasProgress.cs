using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgress
{
    public event EventHandler<OnProgressChangedEvevtArgs> OnProgressChanged;
    public class OnProgressChangedEvevtArgs : EventArgs
    {
        public float progressNormalized;
    }
}
