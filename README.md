# Timbo Jimbo - Motion

Changes made on springs, as SwiftUI's `withAnimation`: what a change moves sets off from where it is drawn, at the velocity it has, and the change says when everything it moved has landed. The motion under [UI Layout](https://github.com/Timbo-Jimbo/UI.Layout) and [Variants](https://github.com/Timbo-Jimbo/Variants).

🌀 **Changes**

`MotionSystem.Animate` makes the change its update makes, and moves what it changes on springs. A change carries an animation, its own or the default. What it moves can be given an animation of its own instead, such as a layout node's `Animation`. A change made inside another's update joins that one.

🎚️ **Springs as SwiftUI Gives Them**

A `MotionAnimation` is a perceptual duration and a bounce, with a delay, and a curvature that bows a move across the screen out sideways. The presets are Smooth, Snappy, Bouncy, Arc and None. A duration of 0 (None) is no animation: what moves is there at once, after its delay. Springs are stepped exactly, in closed form, so they play the same at any frame rate. They turn from where they are, at the speed they have, when a change gives them somewhere new to go.

🏁 **Knowing When It Lands**

The returned `MotionTransition` raises `Finished` once everything the change moved has landed or been taken over. `Completed` says whether it got there without being interrupted, and `Skip` puts everything where it was going. A change also carries type names, and `interactive: false` lets the pointer through what it moves until it lands.

🎨 **Your Own Values**

A value you draw yourself, such as a colour, a radius or anything up to four numbers, moves with the change being made through `MotionSystem.AnimateValue`. The change waits for it as it waits for everything else. `MotionSystem.Current` is the change being made, while `Animate`'s update runs.

⏱️ **UI Time**

Springs step once a frame, just before canvases are drawn, on unscaled time, so UI moves in a pause menu. In edit mode nothing animates.

# Usage

```csharp
var snappy = MotionAnimation.Default.Use(MotionAnimationPreset.Snappy);
MotionSystem.Animate(snappy, () =>
{
    panel.Width = Sizing.Fixed(480f);              // a UI Layout node springs to its new size
    MotionSystem.AnimateValue(this, "tint", Tint, Color.red, snappy, v => Tint = v);  // and a value of your own with it
}).Finished += () => Debug.Log("landed");
```

# Limits

- What a change moves is worked out once its update has run, so part of an update can't be given an animation of its own. A change made inside another joins it, on the outer change's animation.
- Springs and their bookkeeping are internal, shared only with UI Layout. Other code moves values with `AnimateValue`.
