DELIMITER $$

CREATE TRIGGER tr_medicion_desechada
BEFORE UPDATE ON Mediciones
FOR EACH ROW
BEGIN
    IF OLD.estado <> 'Desechado' AND NEW.estado = 'Desechado' THEN
        SET NEW.fechaDesecho = NOW();
    END IF;
    
    IF OLD.estado = 'Desechado' THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'No se puede modificar una medición de un equipo que ya ha sido desechado.';
    END IF;
END$$

DELIMITER ;