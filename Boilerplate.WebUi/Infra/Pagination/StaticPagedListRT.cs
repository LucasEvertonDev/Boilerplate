using System.Collections.Generic;
using X.PagedList;

namespace Boilerplate.WebUi.Infra.Pagination
{

    /// <summary>
    /// Classe auxiliar para paginação.
    /// </summary>
    /// <Date>08/01/2016 21:44:35</Date>
    public class StaticPagedListRT<T> : StaticPagedList<T>
    {
        /// <summary>
        /// Controller a ser acionado.
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Alçao do controller a ser disparada para paginação.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Query com os filtros aplicados.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Id da div da paginacao
        /// </summary>
        public string UpdateTargetID { get; set; }

        /// <summary>
        /// Cria um objeto para controlar a paginação.
        /// </summary>
        /// <param name="itens">itens a serem paginados.</param>
        /// <param name="pageNumber">número da página corrente.</param>
        /// <param name="pageSize">tamanho das páginas.</param>
        /// <param name="totalItens">total dos itens.</param>
        public StaticPagedListRT(IEnumerable<T> itens, int pageNumber, int pageSize, int totalItens)
            : base(itens, pageNumber, pageSize, totalItens)
        {
        }
    }
}

