using UnityEngine;
using System.Collections;

public interface ISelectionInterfaceDown {
    void OnRightClickDown();
    void OnLeftClickDown();
}

public interface ISelectionInterfaceHold
{
    void OnRightClickHold();
    void OnLeftClickHold();
}

public interface ISelectionInterfaceUp
{
    void OnRightClickUp();
    void OnLeftClickUp();
}

