namespace TimboJimbo.Motion
{
    /// <summary>
    /// Something that moves its own springs with the changes and the frame (UI.Layout's nodes), registered with
    /// <see cref="MotionSystem.AddDriver"/>. It is told when a change starts and once its update has run, steps and
    /// draws its springs in each frame, and puts what a skipped change moves where it is going. Values something draws
    /// itself need none: <see cref="MotionSystem.AnimateValue"/> moves them.
    /// </summary>
    internal interface IMotionDriver
    {
        /// <summary>
        /// Whether it is in the middle of something a canvas update forced from inside would come back to the frame
        /// from (a layout pass), when the frame waits.
        /// </summary>
        bool Busy { get; }

        /// <summary>Before a change's update runs: what changed before it goes where it goes at once.</summary>
        void BeforeChange();

        /// <summary>Once a change's update has run: what it changed sets off on springs, held by it.</summary>
        void AfterChange(MotionTransition transition);

        /// <summary>Before the frame is stepped (play mode or not).</summary>
        void BeginFrame(bool playing);

        /// <summary>
        /// Steps its springs once a frame with <see cref="MotionSystem.Advance"/> (with <paramref name="step"/> false,
        /// not at all: the frame is drawn again for what a Finished handler changed) and draws them.
        /// </summary>
        void Frame(bool playing, bool step, float dt);

        /// <summary>Once the frame is stepped: whether it set something moving that is to be drawn this frame too.</summary>
        bool HandOn();

        /// <summary>Last in the frame, once everything is drawn: its own events.</summary>
        void EndFrame();

        /// <summary>Puts every spring of its own that <paramref name="transition"/> is moving where it is going.</summary>
        void Skip(MotionTransition transition);
    }
}
