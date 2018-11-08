CREATE TABLE IF NOT EXISTS perfil (
  id_perfil INT NOT NULL AUTO_INCREMENT,
  deta_perfil VARCHAR(30) NULL,
  PRIMARY KEY (id_perfil));

 INSERT INTO perfil (deta_perfil) VALUES ('Administrador');
INSERT INTO perfil (deta_perfil) VALUES ('Vendedor');
INSERT INTO perfil (deta_perfil) VALUES ('Almacenero');
