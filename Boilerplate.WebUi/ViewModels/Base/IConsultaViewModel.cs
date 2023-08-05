using Boilerplate.Core.Models.IModels;
using Boilerplate.WebUi.Infra.Pagination;

namespace Boilerplate.WebUi.ViewModels.Base;

public interface IConsultaViewModel
{
    /// <summary>
    /// Indica que a consulta é realizada via popup.
    /// </summary>

    /// <summary>
    /// Itens recuperados.
    /// </summary>
    StaticPagedListRT<IModel> Itens { get; set; }
}
