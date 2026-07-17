DELIMITER $$

CREATE TRIGGER tr_registrar_fecha_arreglo
BEFORE UPDATE ON Mediciones
FOR EACH ROW
BEGIN
    IF OLD.estado <> 'Operativo' AND NEW.estado = 'Operativo' THEN
        SET NEW.fechaArreglo = NOW();
    END IF;
END$$

DELIMITER ;