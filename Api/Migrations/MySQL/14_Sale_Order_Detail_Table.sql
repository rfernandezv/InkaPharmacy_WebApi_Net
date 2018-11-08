CREATE TABLE IF NOT EXISTS sale_order_detail (
  sale_order_detail_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  sale_order_id BIGINT UNSIGNED NOT NULL,
  product_id BIGINT UNSIGNED NOT NULL,
  quantity INT NOT NULL,
  price DECIMAL(19,4) NOT NULL,
  currency VARCHAR(3) NOT NULL,
  status INT NULL,
  PRIMARY KEY (sale_order_detail_id),
  CONSTRAINT FK__detalleVe__cod_m__1FCDBCEB
    FOREIGN KEY (product_id)
    REFERENCES product (product_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK__detalleVe__nro_v__1ED998B2
    FOREIGN KEY (sale_order_id)
    REFERENCES sale_order (sale_order_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
	ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;