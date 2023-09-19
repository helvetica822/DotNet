using Reactive.Bindings.Interactivity;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace PE.ReactiveProperty.Extended4DotNet.Converters
{

    public class DataGridAutoGeneratingColumnEventConverter : ReactiveConverter<DataGridAutoGeneratingColumnEventArgs, DataGridColumn>
    {

        protected override IObservable<DataGridColumn?> OnConvert(IObservable<DataGridAutoGeneratingColumnEventArgs?> source)
        {
            return source.Select(x => x?.Column);
        }

    }
}
