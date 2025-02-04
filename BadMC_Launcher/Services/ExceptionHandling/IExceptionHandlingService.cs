namespace BadMC_Launcher.Services.ExceptionHandling;
public interface IExceptionHandlingService {
    public void ToastException(string title, string message, Exception? exception = null, Action? action = null);

    public void DialogException(string title, string message, Exception? exception = null, Action? action = null);
}
