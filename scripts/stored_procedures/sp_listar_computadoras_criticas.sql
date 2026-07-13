DELIMITER //

CREATE PROCEDURE sp_listar_computadoras_criticas ()
BEGIN
    SELECT 
        c.idPC, c.codigoInventario, c.numero_serie, c.sistemaOperativo, c.tipoPC,
        l.nombre AS lab_nombre,
        fn_promedio_temperatura(c.idPC) AS temperatura_promedio_historica
    FROM Computadoras c
    INNER JOIN Laboratorio l ON c.id_laboratorio = l.id_laboratorio
    WHERE fn_calcular_estado(c.idPC) = 'Critico';
END //

DELIMITER ;
