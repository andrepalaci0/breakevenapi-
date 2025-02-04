﻿namespace breakevenApi.Domain.Entities.Doenca
{
    public interface IDoencaRepository
    {
        void Create(Doenca doenca);
        Doenca GetById(long id);
        List<Doenca> GetAll();
        void Update(Doenca doenca);
        void Delete(long id);
    }
}
