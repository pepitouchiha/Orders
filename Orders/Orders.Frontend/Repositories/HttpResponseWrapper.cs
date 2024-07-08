using System.Net;

namespace Orders.Frontend.Repositories
{
	public class HttpResponseWrapper<T>
	{
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; set; }
        public bool Error { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado.";
            }
			if (statusCode == HttpStatusCode.BadRequest)
			{
				return await HttpResponseMessage.Content.ReadAsStringAsync();
			}
			if (statusCode == HttpStatusCode.Unauthorized)
			{
				return "Debes estar logueado para acceder al contenido de esta pagina.";
			}
			if (statusCode == HttpStatusCode.Forbidden)
			{
				return "No tienes acceso al contenido de esta pagina.";
			}

            return "Ha ocurrido un error inesperado.";
		}
    }
}
