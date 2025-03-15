    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System;
    using UnityEngine.UI;
    
    
    public interface IUnit {
        Vector3 GetPosition();
        void SetPosition(Vector3 position);
    }