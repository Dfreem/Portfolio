namespace Portfolio.Services;
public class ToastService
{
    public ToastService()
    {
        
    }
    public event EventHandler<ToastEventArgs> ToastEvent = default!;

    public void OnToast(string message, string toastClass = "")
    {
        OnRaiseToastEvent(new(message, toastClass));
    }

    protected virtual void OnRaiseToastEvent(ToastEventArgs args)
    {
        ToastEvent?.Invoke(this, args);
    }
}

public class ToastEventArgs(string message, string cssClass = "") : EventArgs
{
    public string Message { get; set; } = message;

    // TODO upgrade to Enum
    public string CssClass { get; set; } = cssClass;
}