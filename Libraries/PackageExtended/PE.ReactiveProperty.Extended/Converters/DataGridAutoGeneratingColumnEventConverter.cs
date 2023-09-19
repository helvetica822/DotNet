using Reactive.Bindings.Interactivity;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace PE.ReactiveProperty.Extended.Converters
{

    public class DataGridAutoGeneratingColumnEventConverter : ReactiveConverter<DataGridAutoGeneratingColumnEventArgs, DataGridColumn>
    {

        protected override IObservable<DataGridColumn> OnConvert(IObservable<DataGridAutoGeneratingColumnEventArgs> source)
        {
            return source.Select(x => x.Column);
        }

    }
}
