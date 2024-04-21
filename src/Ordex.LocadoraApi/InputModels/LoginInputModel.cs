namespace Ordex.LocadoraApi.InputModels
{
    public class LoginInputModel
    {
        public required string Email { get; init; }
        public required string Senha { get; init; }
    }
}
