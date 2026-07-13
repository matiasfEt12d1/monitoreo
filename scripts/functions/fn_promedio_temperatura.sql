DELIMITER //

CREATE FUNCTION fn_promedio_temperatura (p_idPC INT)
RETURNS DECIMAL(5,2)
DETERMINISTIC
BEGIN
    DECLARE v_promedio DECIMAL(5,2);

    SELECT AVG(temperaturaCPU) 
    INTO v_promedio
    FROM Mediciones
    WHERE idPC = p_idPC;

    RETURN IFNULL(v_promedio, 0.0);
END //

DELIMITER ;
