using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IUIComponent
{
    void Enter(Flow flow);
    void Exit(Flow flow);
}
