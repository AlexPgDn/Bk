namespace WebApplication.Contracts
{   
    public record BookResponse
        (Guid Id,
        string Title,
        string Description,
        decimal Price,
        int Pages);   
}
