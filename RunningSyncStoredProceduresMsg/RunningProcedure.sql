CREATE OR ALTER PROCEDURE RunningProcedure
AS
BEGIN
    -- Enviar mensagem parcial (progresso)
    RAISERROR('Process beginning...', 0, 1) WITH NOWAIT;

    -- Simula uma operação demorada
    WAITFOR DELAY '00:00:05';

    -- Enviar outra mensagem parcial
    RAISERROR('25%% of process...', 0, 1) WITH NOWAIT;

    -- Simula mais uma operação demorada
    WAITFOR DELAY '00:00:05';

    -- Enviar outra mensagem parcial
    RAISERROR('50%% of process...', 0, 1) WITH NOWAIT;

    -- Simula mais uma operação demorada
    WAITFOR DELAY '00:00:05';
   
    -- Enviar outra mensagem parcial
    RAISERROR('75%%... of process', 0, 1) WITH NOWAIT;

    -- Simula mais uma operação demorada
    WAITFOR DELAY '00:00:05';   

    -- Enviar mensagem final
    RAISERROR('Process finished!', 0, 1) WITH NOWAIT;
END;