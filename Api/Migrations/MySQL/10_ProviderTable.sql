CREATE TABLE  IF NOT EXISTS provider (
  provider_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(20) NOT NULL,
  document_number VARCHAR(30) NOT NULL,
  address VARCHAR(30) NULL,
  telephone VARCHAR(30) NULL,
  status INT NULL,
  PRIMARY KEY (provider_id))
  ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Inversiones ABC','203030301','Av Perú 123','3720001',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Mediprov','203030302','Av Perú 124','3720002',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Labomed','203030303','Av Perú 125','3720003',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Distribuidor ABC','203030304','Av Perú 126','3720004',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Rubimed','203030305','Av Perú 127','3720005',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Trujimed','203030306','Av Perú 128','3720006',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Cajamed','203030307','Av Perú 129','3720007',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Limamed','203030308','Av Perú 130','3720008',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Piuramed','203030309','Av Perú 131','3720009',1);
INSERT INTO provider (name, document_number,address,telephone,status) VALUES ('Tacnamed','203030310','Av Perú 132','3720010',1);