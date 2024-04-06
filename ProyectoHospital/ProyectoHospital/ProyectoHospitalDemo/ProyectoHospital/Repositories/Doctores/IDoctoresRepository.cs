namespace Hospital.Repositories.Doctores
{
    public interface IDoctoresRepository
    {
        string? GetAll();
        object GetAllHospitales();
        string? GetById(int id);
    }
}
