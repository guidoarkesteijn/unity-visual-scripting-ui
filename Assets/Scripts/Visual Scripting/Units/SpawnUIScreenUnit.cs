using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnUIScreenUnit : Unit
{    
    [DoNotSerialize]
    public ControlInput inputStart { get; private set; }
    [DoNotSerialize]
    public ControlInput inputStop { get; private set; }
    [DoNotSerialize]
    public ControlOutput output { get; private set; }
    [DoNotSerialize]
    public ValueInput valueIn { get; private set; }

    private Object spawnedPrefab;
    private IUIComponent[] components;

    protected override void Definition()
    {
        inputStart = ControlInput("enter", Enter);
        inputStart = ControlInput("exit", Destroy);
        inputStop = ControlInput("destroy", Destroy);

        valueIn = ValueInput<Object>("prefab");
    }

    public ControlOutput Enter(Flow flow)
    {
        Object prefab = flow.GetValue<Object>(valueIn);

        spawnedPrefab = Object.Instantiate(prefab);
        Object.DontDestroyOnLoad(spawnedPrefab);

        components = spawnedPrefab.GetComponentsInChildren<IUIComponent>();
        EnterComponents(flow, components);

        return null;
    }

    private ControlOutput Destroy(Flow flow)
    {
        ExitComponents(flow, components);

        if (spawnedPrefab)
        {
            Object.Destroy(spawnedPrefab);
        }
        return null;
    }

    public Object ReturnInstance(Flow flow)
    {
        return spawnedPrefab;
    }

    private void EnterComponents(Flow flow, IUIComponent[] components)
    {
        for (int i = 0; i < components.Length; i++)
        {
            var component = components[i];
            component.Enter(flow);
        }
    }

    private void ExitComponents(Flow flow, IUIComponent[] components)
    {
        for (int i = 0; i < components.Length; i++)
        {
            var component = components[i];
            component.Exit(flow);
        }
    }
}
