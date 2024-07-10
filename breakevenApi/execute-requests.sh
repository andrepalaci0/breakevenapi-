#!/bin/bash

# Create a new medic
curl -X 'POST' \
  'http://localhost:5000/medic' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "crm": 1,
  "percentual": 10,
  "telefone": "1194115551",
  "nomeMedico": "Dr Joao",
  "codigoEspecialidade": 1
}'

# Create a new specialty
curl -X 'POST' \
  'http://localhost:5000/especialidade' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "codigo": 1,
  "indice": 1,
  "nome": "Oftalmologia"
}'

# Create a new disease
curl -X 'POST' \
  'http://localhost:5000/doenca/create' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '"Catarata"'

# Schedule a consultation
curl -X 'POST' \
  'http://localhost:5000/consulta/agenda-consulta?NomePaciente=Miguel&TelefonePaciente=1194111401&CPFPaciente=064998778&CodigoEspecialidade=1&HoraInicio=10&MinutoInicio=0&HoraFim=11&MinutoFim=0&DiaConsulta=13&MesConsulta=02&AnoConsulta=2025&NomeMedicoPreferencia=Dr%20Joao' \
  -H 'accept: */*' \
  -d ''

# Finalize the consultation
curl -X 'PATCH' \
  'http://localhost:5000/consulta/finaliza?IdEsp=1&IdPaciente=1&IdMedico=1&HoraInicio=10&MinutoInicio=0&HoraFim=11&MinutoFim=0&DiaConsulta=13&MesConsulta=02&AnoConsulta=2025&FormaPagamento=PIX&ValorPagamento=190&Diagnostico.Message=Catarata&Diagnostico.RemediosReceitados=Col%C3%ADrio&Diagnostico.TratamentosRecomendados=Cirurgia&Diagnostico.IdConsulta=11113' \
  -H 'accept: */*'
