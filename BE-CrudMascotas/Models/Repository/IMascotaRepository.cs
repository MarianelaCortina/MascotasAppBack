﻿namespace BE_CrudMascotas.Models.Repository
{
    public interface IMascotaRepository
    {
        Task<List<Mascota>> GetListMascotas();
        Task<Mascota> GetMascotaById(int id);
        Task DeleteMascota(Mascota mascota);
        Task<Mascota> AddMascota(Mascota mascota);
        Task UpdateMascota(Mascota mascota);
    }
}
