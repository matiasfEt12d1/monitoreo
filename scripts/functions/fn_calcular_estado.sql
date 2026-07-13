DELIMITER //

CREATE FUNCTION fn_calcular_estado (p_idPC INT)
RETURNS VARCHAR(20)
DETERMINISTIC
BEGIN
    DECLARE v_tipoPC VARCHAR(20);
    DECLARE v_max_temp DECIMAL(5,2);
    DECLARE DECLARE v_ultimaTemp DECIMAL(5,2);
    DECLARE v_ultimoUsoRam DECIMAL(5,2);
    DECLARE v_estado VARCHAR(20) DEFAULT 'Normal';

    -- Obtener el tipo de PC y su configuración
    SELECT tipoPC, max_temperatura_tolerada 
    INTO v_tipoPC, v_max_temp
    FROM Computadoras 
    WHERE idPC = p_idPC;

    -- Obtener la última medición registrada (C# -> _mediciones[^1])
    SELECT temperaturaCPU, usoRAM 
    INTO v_ultimaTemp, v_ultimoUsoRam
    FROM Mediciones
    WHERE idPC = p_idPC
    ORDER BY fechaIngreso DESC
    LIMIT 1;

    -- Si no hay mediciones, no está en estado crítico
    IF v_ultimaTemp IS NULL THEN
        RETURN v_estado;
    END IF;

    -- Lógica de negocio por tipo de equipo
    IF v_tipoPC = 'Escritorio' THEN
        IF v_ultimaTemp > 85.0 OR v_ultimoUsoRam > 95.0 THEN
            SET v_estado = 'Critico';
        END IF;
    ELSEIF v_tipoPC = 'Servidor' THEN
        -- Si no se define temperatura específica, usa la de por defecto en C# (70.0)
        IF v_max_temp IS NULL THEN 
            SET v_max_temp = 70.0; 
        END IF;
        
        IF v_ultimaTemp > v_max_temp OR v_ultimoUsoRam > 90.0 THEN
            SET v_estado = 'Critico';
        END IF;
    END IF;

    RETURN v_estado;
END //

DELIMITER ;
