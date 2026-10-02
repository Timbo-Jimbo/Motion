## [Unreleased]

The first version: UI Layout's springs and changes, in a package of their own for anything that moves with a change.

### Added

- `MotionSystem.Animate`: a change made inside it moves what it changes on springs, from where it is drawn and at the velocity it has, as SwiftUI's `withAnimation`. It carries an animation (`Animate(animation, update)`, or `MotionAnimation.Default`), which what it moves can override with its own (a layout node's `Animation`). Type names, and `interactive: false` to let the pointer through what it moves until it lands. A change made inside another's update joins it
- `MotionSystem.Current`: the change being made, while `Animate`'s update runs
- `MotionSystem.AnimateValue`: a value something draws itself (a colour, a corner radius; up to four components) moves with the change being made: on a spring, from where it is drawn at the velocity it has, held by the change until it comes to rest, and put there when the change is skipped. Outside a change it goes there at once, or, on its way, heads there instead
- `MotionAnimation`: a spring as SwiftUI gives one, a perceptual duration and a bounce, with a delay and a curvature that bows a move across the screen out sideways. Presets (`MotionAnimationPreset`): Smooth, Snappy, Bouncy, Arc and None. A duration of 0 (None) is no animation, as UIKit's zero-duration one: what it moves is there in the change's frame, or once its delay is up. In the inspector, a row of presets lit by the one it matches (None by a duration of 0 alone)
- `MotionTransition`: the change's `Animation`, `Types`, `Interactive`, `Finished`, `Completed` and `Skip`
- `OptionalMotionAnimation`: an animation that may be left on Inherit, read and written as a `MotionAnimation?` (a layout node's, a variant group's). In the inspector, the row of presets with Inherit first
