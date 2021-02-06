using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesUnit : Unit
{
    [DoNotSerialize]
    public ControlInput inputEnter { get; private set; }
    [DoNotSerialize]
    public ControlInput inputExit { get; private set; }

    [DoNotSerialize]
    public ValueInput scenesIn { get; private set; }

    [DoNotSerialize]
    public ValueInput loadAdditiveIn { get; private set; }

    protected override void Definition()
    {
        inputEnter = ControlInput("enter", OnEnter);
        inputExit = ControlInput("exit", OnExit);

        scenesIn = ValueInput<string[]>("scenes");
        loadAdditiveIn = ValueInput<bool>("loadAdditive");
    }

    ControlOutput OnEnter(Flow flow)
    {
        string[] scenesToLoad = flow.GetValue<string[]>(scenesIn);
        bool loadAdditive = flow.GetValue<bool>(loadAdditiveIn);

        foreach (var item in scenesToLoad)
        {
            SceneManager.LoadSceneAsync(item, loadAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
        }

        return null;
    }

    ControlOutput OnExit(Flow flow)
    {
        string[] scenesToLoad = flow.GetValue<string[]>(scenesIn);

        foreach (var item in scenesToLoad)
        {
            SceneManager.UnloadSceneAsync(item);
        }

        return null;
    }
}
