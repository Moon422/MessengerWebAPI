namespace MessengerWebAPI.ViewModels
{
    public interface IShowModelConvertible<TModel, TViewModel>
    {
        abstract static TViewModel FromModel(TModel model);
    }

    public interface IShowViewModelConvertible<TDto>
    {
        TDto ToDto();
    }

    public interface ICreateViewModelConvertible<TModel>
    {
        TModel ToModel();
    }

    public interface ICreateViewModelConvertible<TModel, TDependentModel>
    {
        TModel ToModel(TDependentModel model);
    }
}
