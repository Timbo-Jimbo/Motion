using System.Runtime.CompilerServices;

// UI.Layout drives its nodes' springs with the bookkeeping that tells a change when everything it moved has landed
// (Spring, Hold, Release, Advance and the rest), which is not public.
[assembly: InternalsVisibleTo("TimboJimbo.UI.Layout.Runtime")]
[assembly: InternalsVisibleTo("TimboJimboEditor.Motion")]
