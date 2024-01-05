CREATE TABLE db.Cliente (
 cpf BIGINT auto_increment NOT NULL,
 nome VARCHAR(60) NOT NULL,
 dtNasc DATE NOT NULL,
 CONSTRAINT client_PK PRIMARY KEY (cpf)
);

CREATE TABLE db.Modelo (
 codMod INT auto_increment NOT NULL,
 Desc_2 VARCHAR(40) NOT NULL,
 CONSTRAINT modelo_PK PRIMARY KEY (codMod)
);

CREATE TABLE db.Veiculo (
 placa VARCHAR(8) NOT NULL,
 Modelo_codMod int NOT NULL,
 Cliente_cpf BIGINT NOT NULL,
 cor VARCHAR(20) DEFAULT NULL,
 CONSTRAINT veiculo_PK PRIMARY KEY (placa)
);

ALTER TABLE db.Veiculo ADD CONSTRAINT Veiculo_Cliente_FK FOREIGN KEY (Cliente_cpf) REFERENCES db.Cliente(cpf);

ALTER TABLE db.Veiculo ADD CONSTRAINT Veiculo_Modelo_FK FOREIGN KEY (Modelo_codMod) REFERENCES db.Modelo(codMod);

CREATE TABLE db.Patio (
 num INT auto_increment NOT NULL,
 ender VARCHAR(40) NOT NULL,
 capacidade INT NOT NULL,
 CONSTRAINT patio_PK PRIMARY KEY (num)
);

CREATE TABLE db.Estaciona (
    cod INT auto_increment NOT NULL,
 Patio_num INT NOT NULL,
 Veiculo_Placa VARCHAR(8) NOT NULL,
 dtEntrada VARCHAR(10) NOT NULL,
    dtSaida VARCHAR(10) NOT NULL,
    hsEntrada VARCHAR(10) NOT NULL,
    hsSaida VARCHAR(10) NOT NULL,
 CONSTRAINT estaciona_PK PRIMARY KEY (cod)
);

ALTER TABLE db.Estaciona ADD CONSTRAINT Estaciona_Patio_FK FOREIGN KEY (Patio_num) REFERENCES db.Patio(num);

ALTER TABLE db.Estaciona ADD CONSTRAINT Estaciona_Veiculo_FK FOREIGN KEY (Veiculo_Placa) REFERENCES db.Veiculo(placa);


INSERT INTO Cliente(cpf, nome,  dtNasc) VALUES (12312312312, 'Joao', '19860101');
INSERT INTO Cliente(cpf, nome,  dtNasc) VALUES (12312312313, 'Jose', '19860201');
INSERT INTO Cliente(cpf, nome,  dtNasc) VALUES (12312312314, 'Jonas', '19860301');

INSERT INTO Modelo(Desc_2) VALUES ('Palio');
INSERT INTO Modelo(Desc_2) VALUES ('Gol');
INSERT INTO Modelo(Desc_2) VALUES ('Fusca');

INSERT INTO Patio(ender, capacidade) VALUES ('Barra Funda', 10);
INSERT INTO Patio(ender, capacidade) VALUES ('Santana', 10);
INSERT INTO Patio(ender, capacidade) VALUES ('Interlagos', 10);

INSERT INTO Veiculo(placa, Modelo_codMod, Cliente_cpf, cor) 
    SELECT 'ABCD1234', m.codMod, c.cpf, 'Branco'
    FROM Modelo m, Cliente c
    WHERE m.Desc_2 = 'Palio'
      AND c.nome = 'Joao';

INSERT INTO Veiculo(placa, Modelo_codMod, Cliente_cpf, cor) 
    SELECT 'BTG-2022', m.codMod, c.cpf, 'Branco'
    FROM Modelo m, Cliente c
    WHERE m.Desc_2 = 'Gol'
      AND c.nome = 'Joao';

INSERT INTO Veiculo(placa, Modelo_codMod, Cliente_cpf, cor) 
    SELECT 'ABCD1235', m.codMod, c.cpf, 'Branco'
    FROM Modelo m, Cliente c
    WHERE m.Desc_2 = 'Palio'
      AND c.nome = 'Jose';

INSERT INTO Veiculo(placa, Modelo_codMod, Cliente_cpf, cor) 
    SELECT 'ABCD1236', m.codMod, c.cpf, 'Branco'
    FROM Modelo m, Cliente c
    WHERE m.Desc_2 = 'Fusca'
      AND c.nome = 'Jonas';


INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'BTG-2022', '20230101', '20230101', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Santana';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'BTG-2022', '20230201', '20230201', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Santana';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'ABCD1235', '20230101', '20230101', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Barra Funda';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'BTG-2022', '20230401', '20230401', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Interlagos';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'ABCD1236', '20230101', '20230101', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Barra Funda';


INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'BTG-2022', '20230601', '20230601', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Santana';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'ABCD1234', '20231001', '20231001', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Santana';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'ABCD1235', '20231101', '20231101', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Barra Funda';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'BTG-2022', '20231201', '20231201', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Interlagos';

INSERT INTO Estaciona (Patio_num, Veiculo_Placa, dtEntrada,    dtSaida,    hsEntrada,    hsSaida)
SELECT p.num, 'ABCD1234', '20230801', '20230801', '15:30:00', '17:30:00'
 FROM Patio p
WHERE p.ender = 'Barra Funda';
