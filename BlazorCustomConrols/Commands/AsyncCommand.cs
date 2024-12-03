using System.Windows.Input;

namespace BlazorCustomConrols.Commands;

public interface IAsyncCommand : ICommand
{
    Task ExecuteAsync();
    bool CanExecute();
}


//-------------------------------------------------------------------------------------------------!

public static class TaskUtility
{
    public static async void FireAndForgetSafeAsync(this Task task)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
    {
        try
        {
            await task;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

//-------------------------------------------------------------------------------------------------!

public class AsyncCommand : IAsyncCommand
{
    public event EventHandler? CanExecuteChanged;

    private bool isExecuting_;
    private readonly Func<Task> execute_;
    private readonly Func<bool>? canExecute_;

    public AsyncCommand(
        Func<Task> execute,
        Func<bool>? canExecute = null
       )
    {
        execute_ = execute;
        canExecute_ = canExecute;
    }

    public bool CanExecute()
    {
        return !isExecuting_ && (canExecute_?.Invoke() ?? true);
    }

    public async Task ExecuteAsync()
    {
        if (CanExecute())
        {
            try
            {
                isExecuting_ = true;
                await execute_();
            }
            finally
            {
                isExecuting_ = false;
            }
        }

        RaiseCanExecuteChanged();
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    #region Explicit implementations
    bool ICommand.CanExecute(object? parameter) => CanExecute();


    void ICommand.Execute(object? parameter) => ExecuteAsync().FireAndForgetSafeAsync();

    #endregion
}
