using System;
using Unity.VisualScripting;

[UnitCategory("Events")]
public class FlowTransitionUnit : GameObjectEventUnit<CustomEventArgs>
{
    protected override string hookName => EventHooks.Custom;

    [DoNotSerialize]
    public ValueInput eventValueIn { get; private set; }

    public override Type MessageListenerType => null;

    protected override void Definition()
    {
        base.Definition();

        eventValueIn = ValueInput("eventName", "<EVENT>");
    }

    protected override bool ShouldTrigger(Flow flow, CustomEventArgs args)
    {
        return CompareNames(flow, eventValueIn, args.name);
    }
}
