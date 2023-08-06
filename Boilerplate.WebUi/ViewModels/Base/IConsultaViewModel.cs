using Boilerplate.Core.Models.IModels;
using Boilerplate.WebUi.Infra.Pagination;

namespace Boilerplate.WebUi.ViewModels.Base;

public interface IConsultaViewModel
{
   
    int PageSize { get; set; }

    /// <summary>
    /// Itens recuperados.
    /// </summary>
    StaticPagedListRT<IModel> Itens { get; set; }
}
