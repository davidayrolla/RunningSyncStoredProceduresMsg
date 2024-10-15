CREATE OR ALTER PROCEDURE RunningProcedure
AS
BEGIN
    -- Send partial message (progress)
    RAISERROR('Process beginning...', 0, 1) WITH NOWAIT;

    -- Simulate a long-running operation
    WAITFOR DELAY '00:00:01';

    -- Send another partial message
    RAISERROR('25%% of process...', 0, 1) WITH NOWAIT;

    -- Simulate another long-running operation
    WAITFOR DELAY '00:00:01';

    -- Send another partial message
    RAISERROR('50%% of process...', 0, 1) WITH NOWAIT;

    -- Simulate another long-running operation
    WAITFOR DELAY '00:00:01';

    -- Send another partial message
    RAISERROR('75%%... of process', 0, 1) WITH NOWAIT;

    -- Simulate another long-running operation
    WAITFOR DELAY '00:00:01';

    -- Send final message
    RAISERROR('Process finished!', 0, 1) WITH NOWAIT;
END;