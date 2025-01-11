namespace SMSApp.Behaviours;

public partial class GradeValidationBehavior : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry bindable)
    {
        bindable.TextChanged += OnTextChanged;
        base.OnAttachedTo(bindable);
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
        bindable.TextChanged -= OnTextChanged;
        base.OnDetachingFrom(bindable);
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            if (double.TryParse(entry.Text, out double value))
            {
                if (value < 0 || value > 100)
                {
                    entry.TextColor = Colors.Red;
                }
                else
                {
                    entry.TextColor = Colors.White;
                }
            }
            else
            {
                entry.TextColor = Colors.Red;
            }
        }
    }
}
