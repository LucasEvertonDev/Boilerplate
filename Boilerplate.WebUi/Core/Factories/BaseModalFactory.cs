using Boilerplate.WebUi.Infra.Pagination;

namespace Boilerplate.WebUi.Core.Factories;

public class BaseModalFactory
{

    /// <summary>
    /// Realiza a paginação dos itens recebidos;
    /// </summary>
    /// <typeparam name='T'>tipo do item paginado.</typeparam>
    /// <param name='itens'>itens para paginação.</param>
    /// <param name='page'>pagina para exibição.</param>
    /// <param name='pageSize'>tamanho da página.</param>
    /// <param name='totalItens'>total de itens recuperados.</param>
    /// <param name='query'>filtros aplicados.</param>
    /// <param name='action'>action a ser acionada.</param>
    /// <returns>lista do itens paginados.</returns>
    protected virtual StaticPagedListRT<T> Paging<T>(IEnumerable<T> itens, int page, int pageSize, int totalItens, string query, string action = "Page", string updateTargetID = "pagination-target-div") where T : class
    {
        return new StaticPagedListRT<T>(itens, page, pageSize, totalItens)
        {
            Controller = "Clients",
            Action = action,
            Query = query,
            UpdateTargetID = updateTargetID,
        };
    }
}
