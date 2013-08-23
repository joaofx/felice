namespace Felice.Core.Mvc
{
    public interface IViewModelEnricher<TViewModel>
    {
        void Enrich(TViewModel viewModel);
    }
}
