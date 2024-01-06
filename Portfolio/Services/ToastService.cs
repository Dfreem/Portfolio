namespace Portfolio.Services;
public class ToastService()
{
    
    public event EventHandler<ToastEventArgs> ToastEvent = default!;

    public void Success(string message)
    {
        RaiseToastEvent(new(message,"toast-success"));
    }

    public void Error(string message)
    {
        RaiseToastEvent(new(message,"toast-error"));
    }


    public void Warning(string message)
    {
        RaiseToastEvent(new(message, "toast-warning"));
    }
    protected virtual void RaiseToastEvent(ToastEventArgs args)
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