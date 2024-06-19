-- Listar as consultas (IdMedico, IdPaciente, IdEspecial, Data, HoraInicCon)
-- marcadas pelo paciente “Diego Pituca” com o “Dr. House”.
SELECT C.IdCon AS IdConsulta, C.CRM AS IdMedico, C.IdPac AS IdPaciente, C.IdEsp AS IdEspecialidade, C.Data, C.HoraInicCon
FROM Consulta C
JOIN Paciente P ON C.IdPac = P.IdPac
JOIN Medic M ON C.CRM = M.CRM
WHERE P.NomeP = 'Diego Pituca' AND M.NomeM = 'Dr. House';

--Listar os médicos (CRM, NomeM) que atendem somente na especialidade “Dermatologia”
SELECT M.CRM, M.NomeM
FROM Medic M
JOIN ExerceEsp EE ON M.CRM = EE.CRM
JOIN Especialidade E ON EE.IdEsp = E.IdEsp
WHERE E.NomeEsp = 'Dermatologia'
GROUP BY M.CRM, M.NomeM
HAVING COUNT(*) = 1;

--Listar os médicos (CRM, NomeM) que atendem todas as especialidades.
SELECT M.CRM, M.NomeM
FROM Medic M
JOIN ExerceEsp EE ON M.CRM = EE.CRM
JOIN Especialidade E ON EE.IdEsp = E.IdEsp
GROUP BY M.CRM, M.NomeM
HAVING COUNT(DISTINCT E.IdEsp) = (SELECT COUNT(*) FROM Especialidade);

--Listar os pacientes (CPF, NomeP) consultados pelo “Dr. House” como “Cardiologista”
SELECT DISTINCT P.CPF, P.NomeP
FROM Consulta C
JOIN Paciente P ON C.IdPac = P.IdPac
JOIN Medic M ON C.CRM = M.CRM
JOIN ExerceEsp EE ON M.CRM = EE.CRM
JOIN Especialidade E ON EE.IdEsp = E.IdEsp
WHERE M.NomeM = 'Dr. House'
AND E.NomeEsp = 'Cardiologia';

--Listar o nome dos médicos que atendem consultas todos os dias da semana.
SELECT M.NomeM
FROM Medic M
JOIN Agenda A ON M.CRM = A.CRM
WHERE A.DiaSemana IN ('Segunda-feira', 'Terça-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira') --Consideramos apenas os dias úteis
GROUP BY M.CRM, M.NomeM
HAVING COUNT(DISTINCT A.DiaSemana) = 5;



--Listar as consultas (IdMedico, IdPaciente, IdEspecial, Data, HoraInicCon) feitas no mês de janeiro de 2024.
SELECT C.CRM AS IdMedico, C.IdPac AS IdPaciente, C.IdEsp AS IdEspecialidade, C.Data, C.HoraInicCon
FROM Consulta C
WHERE EXTRACT(MONTH FROM C.Data) = 1 AND EXTRACT(YEAR FROM C.Data) = 2024;


--Qual é a quantidade total de consultas feitas pelo “Dr. House” por especialidade?
SELECT E.NomeEsp AS Especialidade, COUNT(*) AS QuantidadeTotalConsultas
FROM Consulta C
JOIN Medic M ON C.CRM = M.CRM
JOIN ExerceEsp EE ON M.CRM = EE.CRM
JOIN Especialidade E ON EE.IdEsp = E.IdEsp
WHERE M.NomeM = 'Dr. House'
GROUP BY E.NomeEsp;

--Quais são os médicos (CRM, NomeM) com o menor número de consultas atendidas?
SELECT M.CRM, M.NomeM
FROM Medic M
LEFT JOIN Consulta C ON M.CRM = C.CRM
GROUP BY M.CRM, M.NomeM
ORDER BY COUNT(C.IdCon) ASC; -- Ou seja, fizemos uma ordem crescente dos médicos por numero de consultas.

--Remover todos as consultas não pagas.
DELETE FROM Consulta
WHERE Pagou = FALSE;

--Transferir a consulta do paciente “Diego Pituca” no dia “10/05/2024” às 10
--am,na Especialidade “dermatologia”, com o “Dr. House”, para o dia
--“24/05/2024”, na mesma hora, como o “Dr. Kildare”, na mesma especialidade.
UPDATE Consulta
SET CRM = (SELECT M.CRM FROM Medic M WHERE M.NomeM = 'Dr. Kildare'),
    Data = '2024-05-24',
    HoraInicCon = '10:00:00'
WHERE IdPac = (SELECT IdPac FROM Paciente WHERE NomeP = 'Diego Pituca')
  AND Data = '2024-05-10'
  AND HoraInicCon = '10:00:00'
  AND IdEsp = (SELECT IdEsp FROM Especialidade WHERE NomeEsp = 'Dermatologia')
  AND CRM = (SELECT M.CRM FROM Medic M WHERE M.NomeM = 'Dr. House');

