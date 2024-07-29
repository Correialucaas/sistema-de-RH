public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
    public DateTime DateOfBirth { get; set; }
}




public async Task<int> AddEmployee(Employee employee)
{
    using (var connection = new SqlConnection(_connectionString))
    {
        await connection.OpenAsync();
        var sql = "INSERT INTO Employees (Name, Department, Position, DateOfBirth) " +
                  "VALUES (@Name, @Department, @Position, @DateOfBirth); " +
                  "SELECT CAST(SCOPE_IDENTITY() AS INT);";
        var id = await connection.ExecuteScalarAsync<int>(sql, employee);
        return id;
    }
}
