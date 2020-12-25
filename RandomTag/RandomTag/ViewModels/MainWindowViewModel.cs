using Prism.Mvvm;
using Reactive.Bindings;

namespace RandomTag.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; }
            = new("ヒダリウエApp");

        public MainWindowViewModel()
        {

        }
    }
}
