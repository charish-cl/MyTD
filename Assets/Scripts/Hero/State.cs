using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    void OnStateEnter();
    void OnStateUpdate();
    void OnStateExit();
}
