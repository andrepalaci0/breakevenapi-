﻿namespace breakevenApi.Domain.Entities.Paciente;

public interface IPacienteRepository
{
    void Create(Paciente paciente);
    Paciente GetByCodigo(long codigoPaciente);
    Paciente GetByCpf(string cpf);
    List<Paciente> GetAll();
    void Update(Paciente paciente);
    void Delete(long codigoPaciente);
}
