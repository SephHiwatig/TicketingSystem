using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TicketingSystem.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage,
            int itemsPerpage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerpage, totalItems, totalPages);
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
