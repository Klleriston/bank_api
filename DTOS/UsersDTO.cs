namespace bank_api;

public record class UsersDTO(string firstName, string LastName, string document, string email, string password, decimal balance, Type type)
{

}
