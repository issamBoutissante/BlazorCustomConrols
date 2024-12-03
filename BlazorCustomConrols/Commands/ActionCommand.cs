using System.Windows.Input;

namespace BlazorCustomConrols.Commands;

public class ActionCommand : ICommand
{
    private Action action_;
    private Func<bool>? canAct_;
    public ActionCommand(Action ac) => action_ = ac;

    public ActionCommand(Action ac, Func<bool>? canExecute)
    {
        action_ = ac;
        canAct_ = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        if (action_ is null) return false;
        return (canAct_ is null) ? true : canAct_.Invoke();
    }

    public void Execute(object? parameter) => action_?.Invoke();

    public event EventHandler? CanExecuteChanged;
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, noArgs);

    private static readonly EventArgs noArgs = new EventArgs();

}
