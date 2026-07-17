DELIMITER $$

CREATE TRIGGER tr_validar_temperatura_critica
BEFORE INSERT ON Mediciones
FOR EACH ROW
BEGIN
    DECLARE max_temp DECIMAL(5,2);
    
    SELECT max_temperatura_tolerada INTO max_temp 
    FROM Computadoras 
    WHERE idPC = NEW.idPC;
    
    IF max_temp IS NOT NULL AND NEW.temperaturaCPU > max_temp THEN
        SET NEW.estado = 'Crítico';
    END IF;
END$$

DELIMITER ;