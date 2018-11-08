CREATE TABLE IF NOT EXISTS tienda (
  id_tienda INT NOT NULL AUTO_INCREMENT,
  det_tienda VARCHAR(50) NULL,
  estado INT NULL,
  PRIMARY KEY (id_tienda));

INSERT INTO tienda (det_tienda,estado) VALUES ('Los Postes SJL',1);
INSERT INTO tienda (det_tienda,estado) VALUES ('Venezuela UNMSM',1);
INSERT INTO tienda (det_tienda,estado) VALUES ('Plaza San Martin',1);
