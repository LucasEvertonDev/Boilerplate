using System.Text;
using System.Dynamic;
using Newtonsoft.Json;
using System.Reflection;
using Boilerplate.WebUi.ViewModels.Base;
using Boilerplate.WebUi.Infra.Helpers;

namespace Boilerplate.WebUi.Infra.Pagination
{
    /// <summary>
    /// Filtros aplicados na paginação.
    /// </summary>
    public class PagingFilter : DynamicObject
    {
        public PagingFilter() { }

        public PagingFilter(object model, params string[] propertiesName)
        {
            AddFilters(model, propertiesName);
        }

        /// <summary>
        /// Chave de criptografia para geração da query.
        /// </summary>
        private const string ChaveCriptografia = "P@g1ngF1l3r";

        /// <summary>
        /// Dicionário para controlar os filtros.
        /// </summary>
        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        /// <summary>
        /// Número de itens do dicionário.
        /// </summary>
        public int Count
        {
            get
            {
                return _dictionary.Count;
            }
        }

        /// <summary>
        /// Acessor para o dicionário interno.
        /// </summary>
        /// <param name="key">chave de acesso.</param>
        /// <returns>objeto recuperado.</returns>
        public object this[string key]
        {
            get
            {
                return string.IsNullOrEmpty(key) ? null : _dictionary[key];
            }
            set
            {
                if (!string.IsNullOrEmpty(key)) _dictionary[key] = value;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return _dictionary.TryGetValue(name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = value;
            return true;
        }

        /// <summary>
        /// Adiciona os filtros aplicados.
        /// </summary>
        /// <param name="model">objeto para extração dos filtros.</param>
        /// <param name="propertiesName">propriedades para obtenção dos filtros.</param>
        public void AddFilters(object model, params string[] propertiesName)
        {
            if (model != null && propertiesName != null)
            {
                foreach (var propertyName in propertiesName)
                {
                    var property = model.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
                    if (property == null)
                    {
                        throw new FieldAccessException(string.Format("Não foi possível localizar a propriedade {0}", propertyName));
                    }
                    var value = property.GetValue(model, null);
                    if (value != null)
                    {
                        this[propertyName] = value;
                    }
                }
            }
        }

        /// <summary>
        /// Converte os filtros para uma query a ser aplicada.
        /// </summary>
        /// <returns>query com os filtros.</returns>
        public string ToQuery()
        {
            return Count > 0 ? Convert.ToBase64String(Encoding.UTF8.GetBytes(CryptoHelper.Criptografar(ChaveCriptografia, JsonConvert.SerializeObject(_dictionary, Formatting.None)))) : null;
        }

        /// <summary>
        /// Aplica os filtros ao objeto recebido.
        /// </summary>
        /// <param name="obj">objeto que receberá os filtros.</param>
        public void ApplyFilterToObject(object obj)
        {
            foreach (var item in _dictionary)
            {
                var property = obj.GetType().GetProperty(item.Key, BindingFlags.Instance | BindingFlags.Public);
                if (property != null)
                {
                    if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(obj, Enum.Parse(property.PropertyType, item.Value.ToString()));
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(BaseViewModel)))
                    {
                        property.SetValue(obj, JsonConvert.DeserializeObject(item.Value.ToString(), property.PropertyType));
                    }
                    else
                    {
                        property.SetValue(obj, item.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Converte a query recebida para o filtro.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static PagingFilter ConverterQueryToFilter(string query)
        {
            var filter = new PagingFilter();
            if (!string.IsNullOrEmpty(query))
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(CryptoHelper.Decriptografar(ChaveCriptografia, Encoding.UTF8.GetString(Convert.FromBase64String(query))));
                foreach (var item in dictionary)
                {
                    filter[item.Key] = item.Value;
                }
            }
            return filter;
        }
    }
}
