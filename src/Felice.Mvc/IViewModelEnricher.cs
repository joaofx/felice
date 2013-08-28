namespace Felice.Mvc
{
    public interface IViewModelEnricher<TViewModel>
    {
        void Enrich(TViewModel viewModel);
    }
}
