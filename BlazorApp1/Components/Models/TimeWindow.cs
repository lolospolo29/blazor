public abstract class TimeWindow
{
    public abstract bool IsInEntryWindow(DateTime time);
    public abstract bool IsInExitWindow(DateTime time);
    public abstract string ToJson();
}
