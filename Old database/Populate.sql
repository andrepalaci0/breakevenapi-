INSERT INTO Especialidade (NomeEsp, Indice) VALUES
('Clínica Geral', 1),
('Neurologia', 2),
('Cardiologia', 3),
('Dermatologia', 4),
('Oncologia', 5),
('Pediatria', 6),
('Psquiatria', 7);

INSERT INTO Medic (CRM, NomeM, TelefoneM, Percentual) VALUES
('CRM001', 'Dr. João Silva', '123-456-7890', 70.0),
('CRM002', 'Dra. Ana Souza', '987-654-3210', 75.0),
('CRM003', 'Dr. House', '555-555-5555', 80.0), 
('CRM004', 'Dra. Emily Johnson', '111-222-3333', 72.0),
('CRM005', 'Dr. Miguel Pereira', '444-444-4444', 78.0),
('CRM006', 'Dr. Kildare', '123-456-7890', 85.0);

INSERT INTO Paciente (CPF, NomeP, TelefonePac, Endereco, Idade, Sexo) VALUES
('12345678901', 'João Silva', '456-789-0123', 'Rua Principal, 123', 35, 'M'),
('98765432109', 'Ana Souza', '789-012-3456', 'Rua Elm, 456', 40, 'F'),
('11122233345', 'Alice Johnson', '111-222-3333', 'Rua Carvalho, 789', 50, 'F'),
('55566677780', 'Bob Pereira', '555-666-7777', 'Rua Pinheiro, 890', 45, 'M'),
('99988877760', 'Emily Davis', '999-888-7777', 'Rua Maple, 678', 55, 'F'),
('33333333333', 'Diego Pituca', '987-654-3210', 'Rua Elm, 789', 30, 'M'),
('77777777777', 'Maria Garcia', '222-333-4444', 'Rua Carvalho, 456', 60, 'F'),
('88888888888', 'Carlos Silva', '333-444-5555', 'Rua Pinheiro, 890', 25, 'M'),
('66666666666', 'Ana Oliveira', '666-777-8888', 'Rua Maple, 678', 35, 'F'),
('44444444444', 'Pedro Santos', '444-555-6666', 'Rua Principal, 123', 70, 'M');

INSERT INTO Doenca (NomeDoenca) VALUES
('Gripe'),
('Enxaqueca'),
('Hipertensão'),
('Erupção Cutânea'),
('Câncer de Mama');

INSERT INTO ExerceEsp (CRM, IdEsp) VALUES
('CRM001', 1),  -- Dr. João Silva - Clínica Geral
('CRM002', 2),  -- Dra. Ana Souza - Neurologia
('CRM003', 4),  -- Dr. House - Dermatologia
('CRM003', 1),  -- Dr. House - Clínica Geral
('CRM003', 3),  -- Dr. House - Cardiologista
('CRM004', 4),  -- Dra. Emily Johnson - Dermatologia
('CRM004', 7),  -- Dra. Emily Johson - Psquiatria
('CRM001', 7),  -- Dr. João Silva - Psquiatria
('CRM005', 5),  -- Dr. Miguel Pereira - Oncologia
('CRM006', 1),  -- Dr. Kildare - Clínica Geral
('CRM006', 2),  -- Dr. Kildare - Neurologia
('CRM006', 3),  -- Dr. Kildare - Cardiologia
('CRM006', 4),  -- Dr. Kildare - Dermatologia
('CRM006', 5),  -- Dr. Kildare - Oncologia
('CRM006', 6),  -- Dr. Kildare - Pediatria
('CRM006', 7);  -- Dr. Kildare - Psquaitria



INSERT INTO Consulta (CRM, IdEsp, IdPac, Data, HoraInicCon, HoraFimCon, Pagou, ValorPago, FormaPagamento) VALUES
('CRM001', 1, 1, '2024-05-10', '10:00:00', '11:00:00', TRUE, 100.00, 'Dinheiro'),
('CRM002', 2, 1, '2024-05-24', '10:00:00', '11:00:00', FALSE, 0.00, NULL),
('CRM001', 1, 2, '2024-05-05', '09:00:00', '10:00:00', TRUE, 120.00, 'Cartão'),
('CRM003', 4, 6, '2024-05-10', '10:00:00', '12:00:00', TRUE, 90.00, 'Cheque'),
('CRM003', 1, 6, '2024-03-14', '09:00:00', '12:00:00', TRUE, 50.00, 'Pix'),
('CRM001', 1, 5, '2024-05-05', '09:00:00', '10:00:00', TRUE, 70.00, 'Cartão'),
('CRM001', 1, 3, '2024-01-13', '09:00:00', '10:00:00', TRUE, 90.00, 'Dinheiro'),
('CRM001', 7, 3, '2024-01-04', '09:00:00', '10:00:00', TRUE, 200.00, 'Dinheiro'),
('CRM001', 7, 1, '2024-01-06', '09:00:00', '10:00:00', TRUE, 200.00, 'Cartão'),
('CRM001', 7, 2, '2024-01-06', '09:00:00', '10:00:00', TRUE, 200.00, 'Cartão'),
('CRM004', 4, 1, '2024-02-08', '09:00:00', '10:00:00', TRUE, 30.00, 'Pix'),
('CRM005', 5, 5, '2024-03-05', '09:00:00', '10:00:00', TRUE, 60.00, 'Pix'),
('CRM006', 6, 5, '2024-03-15', '09:00:00', '10:00:00', TRUE, 80.00, 'Pix'),
('CRM003', 3, 6, '2024-01-09', '11:00:00', '12:00:00', TRUE, 40.00, 'Cheque'),
('CRM003', 3, 10, '2024-01-17', '09:00:00', '12:00:00', TRUE, 50.00, 'Cartão');

INSERT INTO Agenda (DiaSemana, HoraInicio, HoraFim, CRM)
VALUES
('Segunda-feira', '08:00:00', '12:00:00', 'CRM001'),
('Segunda-feira', '13:00:00', '17:00:00', 'CRM001'),
('Terça-feira', '08:00:00', '12:00:00', 'CRM001'),
('Terça-feira', '13:00:00', '17:00:00', 'CRM001'),
('Quarta-feira', '09:00:00', '17:00:00', 'CRM001'),
('Quinta-feira', '09:00:00', '17:00:00', 'CRM001'),
('Sexta-feira', '09:00:00', '17:00:00', 'CRM001'),
('Quinta-feira', '09:00:00', '17:00:00', 'CRM001'),
('Sexta-feira', '09:00:00', '17:00:00', 'CRM001'),
('Segunda-feira', '08:00:00', '12:00:00', 'CRM002'),
('Quarta-feira', '07:00:00', '17:00:00', 'CRM002'),
('Sexta-feira', '07:00:00', '17:00:00', 'CRM002'),
('Terça-feira', '08:00:00', '12:00:00', 'CRM003'),
('Quinta-feira', '08:00:00', '17:00:00', 'CRM003'),
('Sexta-feira', '08:00:00', '17:00:00', 'CRM003'),
('Terça-feira', '08:00:00', '12:00:00', 'CRM004'),
('Quinta-feira', '08:00:00', '17:00:00', 'CRM004'),
('Segunda-feira', '08:00:00', '12:00:00', 'CRM005'),
('Terça-feira', '08:00:00', '17:00:00', 'CRM005'),
('Quarta-feira', '08:00:00', '12:00:00', 'CRM005'),
('Sexta-feira', '08:00:00', '17:00:00', 'CRM006');
      

 



