CREATE TABLE IF NOT EXISTS purchase_order_detail (
  purchase_order_detail_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  purchase_order_id BIGINT UNSIGNED NOT NULL,
  product_id BIGINT UNSIGNED NOT NULL,
  quantity INT NOT NULL,
  cost DECIMAL(19,4) NOT NULL,
  currency VARCHAR(3) NOT NULL,
  PRIMARY KEY (purchase_order_detail_id),
  CONSTRAINT FK__detalleCo__cod_c__34C8D9D1
    FOREIGN KEY (purchase_order_id)
    REFERENCES purchase_order (purchase_order_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK__detalleCo__cod_m__35BCFE0A
    FOREIGN KEY (product_id)
    REFERENCES product (product_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
	ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
