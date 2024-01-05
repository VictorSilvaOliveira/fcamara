-- 1 Exiba a placa e o nome dos donos de todos os veículos

SELECT v.placa, c.nome 
FROM       Veiculo v 
LEFT JOIN Cliente c ON v.Cliente_cpf = c.cpf 

-- Exiba o endereço, a data de entrada e de saída dos estacionamentos do veículo de placa "BTG-2022"
SELECT p.ender, e.dtEntrada , e.dtSaida
FROM Estaciona e 
LEFT JOIN Patio p ON e.Patio_num = p.num 
WHERE e.Veiculo_Placa  = 'BTG-2022';
