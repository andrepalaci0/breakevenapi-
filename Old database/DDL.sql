CREATE TABLE Agenda (
    IdAgenda SERIAL PRIMARY KEY,
    DiaSemana VARCHAR(20) NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFim TIME NOT NULL,
    CRM VARCHAR(50) NOT NULL
);

CREATE TABLE Medic (
    CRM VARCHAR(50) PRIMARY KEY,
    NomeM VARCHAR(100) NOT NULL,
    TelefoneM VARCHAR(20) NOT NULL,
    Percentual DECIMAL(5, 2) NOT NULL
);

CREATE TABLE Doenca (
    IdDoenca SERIAL PRIMARY KEY, 
    NomeDoenca VARCHAR(100) NOT NULL
);

CREATE TABLE Paciente (
    IdPac SERIAL PRIMARY KEY,
    CPF VARCHAR(11) UNIQUE NOT NULL,
    NomeP VARCHAR(100) NOT NULL,
    TelefonePac VARCHAR(20) NOT NULL,
    Endereco VARCHAR(255),
    Idade BIGINT,
    Sexo CHAR(1)
);

CREATE TABLE Especialidade (
    IdEsp SERIAL PRIMARY KEY,
    NomeEsp VARCHAR(100) NOT NULL,
    Indice BIGINT UNIQUE
);

CREATE TABLE ExerceEsp (
    CRM VARCHAR(50),
    IdEsp BIGINT,
    PRIMARY KEY (CRM, IdEsp),
    FOREIGN KEY (CRM) REFERENCES Medic(CRM),
    FOREIGN KEY (IdEsp) REFERENCES Especialidade(Indice)
);

CREATE TABLE Consulta (
    IdCon SERIAL PRIMARY KEY,
    CRM VARCHAR(50),
    IdEsp BIGINT,
    IdPac BIGINT,
    Data DATE,
    HoraInicCon TIME,
    HoraFimCon TIME,
    Pagou BOOLEAN,
    ValorPago DECIMAL(10, 2),
    FormaPagamento VARCHAR(50),
    FOREIGN KEY (CRM) REFERENCES Medic(CRM),
    FOREIGN KEY (IdEsp) REFERENCES Especialidade(Indice),
    FOREIGN KEY (IdPac) REFERENCES Paciente(IdPac)
	);

CREATE TABLE Diagnostica (
    IdDiagnostica SERIAL PRIMARY KEY,
    IdDoenca BIGINT,
    FOREIGN KEY (IdDoenca) REFERENCES Doenca(IdDoenca)
);


CREATE TABLE Diagnostico (
    IdDiagnostico SERIAL PRIMARY KEY,
    TratamentoRecomendado TEXT,
    RemediosReceitados TEXT,
    Observacoes TEXT,
    IdCon BIGINT,
    FOREIGN KEY (IdDiagnostico) REFERENCES Diagnostica(IdDiagnostica),
    FOREIGN KEY (IdCon) REFERENCES Consulta(IdCon)
);
